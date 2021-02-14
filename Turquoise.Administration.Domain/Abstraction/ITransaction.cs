using System;
using System.Threading.Tasks;

namespace Turquoise.Administration.Domain.Abstraction
{
    public interface ITransaction : IDisposable
    {
        /// <summary>
        /// Rollback operations
        /// </summary>
        /// <returns></returns>
        Task RollbackAsync();

        /// <summary>
        /// Commit operations
        /// </summary>
        /// <returns></returns>
        Task CommitAsync();
    }
}
