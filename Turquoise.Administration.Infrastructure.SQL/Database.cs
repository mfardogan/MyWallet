using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Turquoise.Administration.Infrastructure.SQL
{
    using Turquoise.Administration.Infrastructure.SQL.Tracker;
    using Turquoise.Administration.Domain.Aggregation.Common;
    using Turquoise.Administration.Domain.Aggregation.Branch;
    using Turquoise.Administration.Domain.Aggregation.ChoiceGroup;
    using Turquoise.Administration.Domain.Aggregation.Doctor;
    using Turquoise.Administration.Domain.Aggregation.Administrator;
    using Turquoise.Administration.Domain.Aggregation.Survey;
    using Turquoise.Administration.Domain.Aggregation.SurveyAnswer;

    public class Database : DbContext
    {
        public Database() { }

        public Database([NotNull] DbContextOptions options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = default;
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<ChoiceGroup> ChoiceGroups { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<AdministratorPassword> AdministratorPasswords { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyBranch> SurveyBranches { get; set; }
        public DbSet<SurveyAnswer> SurveyAnswers { get; set; }
        public DbSet<SurveyAnswerChoice> SurveyAnswerChoices { get; set; }


        #region Configuration
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("turquoise_ubuntu"));
            }

            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Build models
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            ConcurrencyTokens(modelBuilder);

            ApplyDefaultSql(modelBuilder,
                e => e.ClrType.BaseType == typeof(Poco<Guid>),
                nameof(Poco<Guid>.Id),
                "uuid_generate_v4()"
               );

            ApplyDefaultSql(modelBuilder,
                e => e.ClrType.BaseType == typeof(ConcurrencyPoco<>),
                nameof(ConcurrencyPoco<Guid>.RowGuid),
                "uuid_generate_v4()");

            ApplyDefaultSql(modelBuilder,
                e => e.ClrType.BaseType.IsGenericType && e.ClrType.BaseType.GetGenericTypeDefinition() == typeof(Poco<>),
                nameof(Poco<object>.RowGuid),
                "uuid_generate_v4()");

            ApplyDefaultSql(modelBuilder,
                e => e.ClrType.BaseType.IsGenericType && e.ClrType.BaseType.GetGenericTypeDefinition() == typeof(ConcurrencyPoco<>),
                nameof(Poco<object>.RowGuid),
                "uuid_generate_v4()");

            ApplyDefaultSql(modelBuilder,
                e => e.ClrType.GetInterfaces().Any(x => x == typeof(ICreationAt)),
                nameof(ICreationAt.CreationAt),
                "now()");

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var subject = new ModelWatcherSubject()
                 .AddObserver(new InsertObserver())
                   .AddObserver(new UpdateObserver())
                     .AddObserver(new DeleteObserver());

            ChangeTracker.DetectChanges();
            subject.Publish(ChangeTracker.Entries());
            return base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Add concurrency tokens for models
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void ConcurrencyTokens(ModelBuilder modelBuilder)
        {
            modelBuilder.Model.GetEntityTypes()
                .Where(e => e.ClrType.BaseType == typeof(ConcurrencyPoco<>))
                .Select(e => e.ClrType)
                .ToList()
                .ForEach(e => modelBuilder.Entity(e).Property(nameof(ConcurrencyPoco<object>.ConcurrencyToken))
                     .HasColumnName("xmin")
                         .HasColumnType("xid")
                              .ValueGeneratedOnAddOrUpdate()
                                     .IsConcurrencyToken());
        }

        /// <summary>
        /// Default value sql
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="filter"></param>
        /// <param name="propertyName"></param>
        /// <param name="defaultSqlValue"></param>
        public static void ApplyDefaultSql(ModelBuilder modelBuilder, Func<IMutableEntityType, bool> filter, string propertyName, string defaultSqlValue)
        {
            modelBuilder.Model.GetEntityTypes()
                .Where(filter)
                .Select(e => e.ClrType)
                .ToList()
                .ForEach(e =>
                {
                    modelBuilder.Entity(e)
                    .Property(propertyName)
                    .HasDefaultValueSql(defaultSqlValue);
                });
        }
        #endregion
    }
}
