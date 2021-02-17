using StackExchange.Redis;

namespace Turquoise.Administration.Infrastructure.Cache
{
    public abstract class CacheService
    {
        private readonly int database;
        protected CacheService(int database = -1) => this.database = database;

        /// <summary>
        /// Get database
        /// </summary>
        public IDatabase Database => Multiplexer.GetDatabase(database);

        /// <summary>
        /// Server
        /// </summary>
        public IConnectionMultiplexer Multiplexer => ConnectionFactory.Multiplexer;
    }
}
