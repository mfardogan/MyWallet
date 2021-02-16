namespace Turquoise.Administration.Domain.Abstraction
{
    public interface IDistributeMemoryCache
    {
        string GetString(string key);
        void SetString(string key, string value);
    }
}
