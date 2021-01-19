using System.IO;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MyWallet.Administration.Infrastructure.Persistence
{
    using MyWallet.Administration.Domain;
    using MyWallet.Administration.Domain.Aggregation.Administrator;
    using MyWallet.Administration.Infrastructure.Multitenancy;

    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var accessor = Dependency.Get<IMultitenancyAccessor>();
            var connectionString = accessor.GetTenancy().ConnectionStrings.Persistence;
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("MyWalletLocal"));
            }

            optionsBuilder.UseNpgsql(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<AdministratorPassword> AdministratorPasswords { get; set; }
    }
}
