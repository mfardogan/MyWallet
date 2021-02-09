using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Domain.Abstraction
{
    public abstract class UnitOfWork
    {
        /// <summary>
        /// Save changes
        /// </summary>
        /// <returns></returns>
        public abstract int Save();

        /// <summary>
        /// Save changes async
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task<int> SaveAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a new transaction
        /// </summary>
        /// <returns></returns>
        public abstract ITransaction BeginTransaction();

        /// <summary>
        /// Get service
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public abstract T GetService<T>() where T : IDAO;
    }
}
