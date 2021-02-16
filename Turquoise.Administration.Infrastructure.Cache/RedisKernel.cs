namespace Turquoise.Administration.Infrastructure.Cache
{
    using Turquoise.Administration.Domain.Abstraction;
    public sealed class RedisKernel : Cache, IDistributeMemoryCache
    {
        public RedisKernel(int database = -1) : base(database)
        {
        }

        /// <summary>
        /// Get string
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string IDistributeMemoryCache.GetString(string key)
        {
            return Database.StringGet(key);
        }

        /// <summary>
        /// Set string
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void IDistributeMemoryCache.SetString(string key, string value)
        {
            _ = Database.StringSet(key, value);
        }
    }
}
