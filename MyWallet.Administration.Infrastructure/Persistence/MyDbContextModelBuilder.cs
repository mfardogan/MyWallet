using Microsoft.EntityFrameworkCore;

namespace MyWallet.Administration.Infrastructure.Persistence
{
    internal partial class MyDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
