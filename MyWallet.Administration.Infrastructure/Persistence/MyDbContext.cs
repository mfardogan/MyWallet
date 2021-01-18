using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using MyWallet.Administration.Domain.Aggregation.Administrator;

namespace MyWallet.Administration.Infrastructure.Persistence
{
    internal partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<AdministratorPassword> AdministratorPasswords { get; set; }
    }
}
