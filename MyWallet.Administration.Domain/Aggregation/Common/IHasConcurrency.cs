namespace MyWallet.Administration.Domain.Aggregation.Common
{
    public interface IHasConcurrency
    {
        uint ConcurrencyToken { get; set; }
    }
}
