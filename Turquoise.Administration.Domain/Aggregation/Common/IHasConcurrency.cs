namespace Turquoise.Administration.Domain.Aggregation.Common
{
    public interface IHasConcurrency
    {
        uint ConcurrencyToken { get; set; }
    }
}
