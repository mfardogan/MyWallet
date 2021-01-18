using System.IO;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyWallet.Administration.Domain.Aggregation.Administrator;

namespace MyWallet.Administration.Infrastructure.Persistence
{
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
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("MyWalletLocal"));
            }
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<AdministratorPassword> AdministratorPasswords { get; set; }
    }
}
