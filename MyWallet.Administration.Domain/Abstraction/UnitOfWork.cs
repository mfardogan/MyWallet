using System.Threading;
using System.Threading.Tasks;

namespace MyWallet.Administration.Domain.Abstraction
{
    public abstract class UnitOfWork
    {
        public abstract int SaveChanges();
        public abstract Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        public abstract ITransaction BeginTransaction();
    }
}
