using Newtonsoft.Json;

namespace Turquoise.Administration.Infrastructure.Cache
{
    using Turquoise.Administration.Domain.Abstraction;
    public sealed class RedisMemoryCache : CacheService, ICacheService
    {
        public RedisMemoryCache(int database = -1) : base(database)
        {
        }

        /// <summary>
        /// Delete key
        /// </summary>
        /// <param name="key"></param>
        public void Delete(string key)
        {
            Database.KeyDelete(key);
        }

        /// <summary>
        /// Key exists
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            return Database.KeyExists(key);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            string value = Database.StringGet(key);
            return string.IsNullOrEmpty(value) ? default :
                JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set(string key, object value)
        {
            Database.StringSet(key, JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// Tryget
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public bool TryGet<T>(string key, out T value)
        {
            bool isKeyExists = Exists(key);
            value = isKeyExists ? Get<T>(key) : default;
            return isKeyExists;
        }
    }
}
