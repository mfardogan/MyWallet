using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace MyWallet.Administration.Infrastructure.Persistence
{
    using MyWallet.Administration.Domain;
    using MyWallet.Administration.Domain.Abstraction;
    using System.Diagnostics;

    public sealed class Transaction : ITransaction
    {
        private readonly IDbContextTransaction _transaction;
        public Transaction(MyDbContext myDbContext)
        {
            _transaction = myDbContext.Database.BeginTransaction();
            Debug.WriteLine(((object)myDbContext).GetHashCode());
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }

        /// <summary>
        /// Commit
        /// </summary>
        /// <returns></returns>
        Task ITransaction.CommitAsync() => _transaction.CommitAsync();

        /// <summary>
        /// Rollback
        /// </summary>
        /// <returns></returns>
        Task ITransaction.RollbackAsync() => _transaction.RollbackAsync();
    }
}
