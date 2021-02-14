using System;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Storage;

namespace Turquoise.Administration.Infrastructure.SQL
{
    using Turquoise.Administration.Domain.Abstraction;

    public sealed class Transaction : ITransaction
    {
        private readonly IDbContextTransaction scope;
        public Transaction([NotNull] Database context)
        {
            scope = context.Database.BeginTransaction();
        }

        /// <summary>
        /// Dispose currenct transaction
        /// </summary>
        void IDisposable.Dispose() => scope.Dispose();

        /// <summary>
        /// Commit
        /// </summary>
        /// <returns></returns>
        Task ITransaction.CommitAsync() => scope.CommitAsync();

        /// <summary>
        /// Rollback
        /// </summary>
        /// <returns></returns>
        Task ITransaction.RollbackAsync() => scope.RollbackAsync();
    }
}
