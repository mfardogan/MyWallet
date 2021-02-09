using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Turquoise.Administration.Infrastructure.SQL
{
    using Turquoise.Administration.Infrastructure.SQL.Tracker;
    using Turquoise.Administration.Domain.Aggregation.Branch;
    using Turquoise.Administration.Domain.Aggregation.Choice;
    using Turquoise.Administration.Domain.Aggregation.ChoiceGroup;
    using Turquoise.Administration.Domain.Aggregation.Common;
    using Turquoise.Administration.Domain.Aggregation.Doctor;
    using Turquoise.Administration.Domain.Aggregation.Administrator;
    public partial class Database : DbContext
    {
        public Database() { }
        public Database([NotNull] DbContextOptions options) : base(options) { }


        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<ChoiceGroup> ChoiceGroups { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<AdministratorPassword> AdministratorPasswords { get; set; }

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
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("TurquoiseLocal"));
            }

            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Build models
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.DefaultSqlValues(
                filter: e => e.ClrType.BaseType == typeof(Entity<Guid>),
                propertyName: nameof(Entity<Guid>.Id),
                defaultSqlValue: "uuid_generate_v4()"
                );

            modelBuilder.DefaultSqlValues(
                filter: e => e.ClrType.BaseType.IsGenericType && e.ClrType.BaseType.GetGenericTypeDefinition() == typeof(Entity<>),
                propertyName: nameof(Entity<object>.RowGuid),
                defaultSqlValue: "uuid_generate_v4()");

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
    }
}
