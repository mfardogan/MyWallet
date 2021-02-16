using StackExchange.Redis;

namespace Turquoise.Administration.Infrastructure.Cache
{
    public abstract class Cache
    {
        private readonly int database;
        protected Cache(int database = -1) => this.database = database;

        /// <summary>
        /// Get database
        /// </summary>
        public IDatabase Database => Connection.Multiplexer.GetDatabase(database);
    }
}
