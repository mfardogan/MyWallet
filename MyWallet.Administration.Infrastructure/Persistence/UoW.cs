using System.Threading;
using System.Threading.Tasks;

namespace MyWallet.Administration.Infrastructure.Persistence
{
    using MyWallet.Administration.Domain;
    using MyWallet.Administration.Domain.Abstraction;

    public class UoW : UnitOfWork
    {
        private readonly MyDbContext myDbContext;
        public UoW() => myDbContext = Dependency.Get<MyDbContext>();

        public override ITransaction BeginTransaction()
        {
            return new Transaction(myDbContext);
        }

        public override T GetService<T>()
        {
            return Dependency.Get<T>();
        }

        public override int Save()
        {
            return myDbContext.SaveChanges();
        }

        public override Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            return myDbContext.SaveChangesAsync();
        }
    }
}
