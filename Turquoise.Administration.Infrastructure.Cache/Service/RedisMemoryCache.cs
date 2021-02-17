using Newtonsoft.Json;

namespace Turquoise.Administration.Infrastructure.Cache.Service
{
    using Turquoise.Administration.Domain.Abstract;
    public sealed class RedisMemoryCache : CacheService, ICacheService
    {
        public RedisMemoryCache() : base(database: -1)
        {
        }

        /// <summary>
        /// Delete key
        /// </summary>
        /// <param name="key"></param>
        public void Delete(string key) => Database.KeyDelete(key);

        /// <summary>
        /// Key exists
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(string key) => Database.KeyExists(key);

        /// <summary>
        /// Clear database
        /// </summary>
        /// <param name="db"></param>
        public void Flush(int database = -1) => Multiplexer.GetServer(ConnectionFactory.Configuration.host).FlushDatabase(database);

        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key) => JsonConvert.DeserializeObject<T>(Database.StringGet(key));

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set(string key, object value) => _ = Database.StringSet(key, JsonConvert.SerializeObject(value));

        /// <summary>
        /// Tryget
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public bool TryGet<T>(string key, out T value)
        {
            var check = Exists(key);
            value = check ? Get<T>(key) : default;
            return check;
        }
    }
}
