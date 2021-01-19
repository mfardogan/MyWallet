using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace MyWallet.Administration.Infrastructure.Persistence
{
    using MyWallet.Administration.Domain;
    using MyWallet.Administration.Domain.Abstraction;

    public sealed class Transaction : ITransaction
    {
        private readonly IDbContextTransaction _transaction;
        public Transaction()
        {
            var context = Dependency.Get<MyDbContext>();
            _transaction = context.Database.BeginTransaction();
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
