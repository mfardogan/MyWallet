namespace Turquoise.Administration.Domain.Abstraction
{
    public interface ICacheService
    {
        T Get<T>(string key);
        bool TryGet<T>(string key, out T value);
        void Set(string key, object value);
        void Delete(string key);
        bool Exists(string key);
    }
}
