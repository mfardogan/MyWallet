using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Infrastructure.SQL
{
    using Turquoise.Administration.Domain;
    using Turquoise.Administration.Domain.Abstract;

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
        /// <typeparam name="TDAO"></typeparam>
        /// <returns></returns>
        public TDAO ServiceAs<TDAO>() where TDAO : IDataAccessObject => Dependency.Get<TDAO>();

        /// <summary>
        /// Begin new transaction
        /// </summary>
        /// <returns></returns>
        public ITransaction BeginTransaction() => new Transaction(_context);

        /// <summary>
        /// Save async
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> SaveAsync(CancellationToken cancellationToken = default) => _context.SaveChangesAsync();
    }
}
