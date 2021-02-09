namespace MyWallet.Administration.Domain.Abstraction
{
    public interface ISaltFactory
    {
        byte[] Generate();
    }
}
