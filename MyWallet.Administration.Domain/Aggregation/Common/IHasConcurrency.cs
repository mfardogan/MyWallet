namespace MyWallet.Administration.Domain.Aggregation.Common
{
    public interface IHasConcurrency
    {
        byte[] RowVersion { get; set; }
    }
}
