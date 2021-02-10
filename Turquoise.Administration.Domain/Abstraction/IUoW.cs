using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Domain.Abstraction
{
    public interface IUoW
    {
        /// <summary>
        /// Save changes async
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a new transaction
        /// </summary>
        /// <returns></returns>
        ITransaction BeginTransaction();

        /// <summary>
        /// Get service
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T ServiceAs<T>() where T : IDataAccessObject;
    }
}
