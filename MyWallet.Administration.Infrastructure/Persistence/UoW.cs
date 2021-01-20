using MyWallet.Administration.Domain;
using MyWallet.Administration.Domain.Abstraction;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MyWallet.Administration.Infrastructure.Persistence
{
    public class UoW : UnitOfWork
    {
        private readonly MyDbContext myDbContext;
        public UoW()
        {
            myDbContext = Dependency.Get<MyDbContext>();
            Debug.WriteLine(((object)myDbContext).GetHashCode());
        }

        public override ITransaction BeginTransaction()
        {
            return new Transaction(myDbContext);
        }

        public override int SaveChanges()
        {
            return myDbContext.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return myDbContext.SaveChangesAsync();
        }
    }
}
