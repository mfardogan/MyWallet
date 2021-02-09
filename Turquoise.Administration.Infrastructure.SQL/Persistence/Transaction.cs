using System;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Storage;

namespace Turquoise.Administration.Infrastructure.SQL.Persistence
{
    using Turquoise.Administration.Domain.Abstraction;

    public sealed class Transaction : ITransaction
    {
        private readonly IDbContextTransaction _transaction;
        public Transaction([NotNull] MyDbContext context)
        {
            _transaction = context.Database.BeginTransaction();
        }

        /// <summary>
        /// Dispose currenct transaction
        /// </summary>
        void IDisposable.Dispose() => _transaction.Dispose();

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
