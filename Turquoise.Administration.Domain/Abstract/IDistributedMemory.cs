namespace Turquoise.Administration.Domain.Abstract
{
    public interface IDistributedMemory
    {
        /// <summary>
        /// Get value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// Get value if exists
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool TryGet<T>(string key, out T value);

        /// <summary>
        /// Set value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Set(string key, object value);

        /// <summary>
        /// Delete an existing key
        /// </summary>
        /// <param name="key"></param>
        void Delete(string key);

        /// <summary>
        /// Check exists
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Exists(string key);

        /// <summary>
        /// Clear database
        /// </summary>
        /// <param name="database"></param>
        void Flush(int database = -1);
    }
}
