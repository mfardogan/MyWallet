namespace Turquoise.Administration.Infrastructure.Cache
{
    using Turquoise.Administration.Domain.Abstraction;
    public sealed class DistributedMemoryCache : IDistributeMemoryCache
    {
        /// <summary>
        /// Get string
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string IDistributeMemoryCache.GetString(string key)
        {
            return ConnectionFactory.Connection
                .GetDatabase()
                .StringGet(key);
        }

        /// <summary>
        /// Set string
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void IDistributeMemoryCache.SetString(string key, string value)
        {
            ConnectionFactory.Connection
                .GetDatabase()
                .StringSet(key, value);
        }
    }
}
