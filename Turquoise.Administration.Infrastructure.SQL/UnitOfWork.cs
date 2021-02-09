using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Infrastructure.SQL
{
    using Turquoise.Administration.Domain;
    using Turquoise.Administration.Domain.Abstraction;

    public class UnitOfWork : IUoW
    {
        private readonly Database _context;
        public UnitOfWork()
        {
            _context = Dependency.Get<Database>();
        }

        /// <summary>
        /// Get service
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ServiceAs<T>() where T : IDAO => Dependency.Get<T>();

        /// <summary>
        /// Begin new transaction
        /// </summary>
        /// <returns></returns>
        public ITransaction BeginTransaction() => new TransactionScope(_context);

        /// <summary>
        /// Save async
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> SaveAsync(CancellationToken cancellationToken = default) => _context.SaveChangesAsync();
    }
}
