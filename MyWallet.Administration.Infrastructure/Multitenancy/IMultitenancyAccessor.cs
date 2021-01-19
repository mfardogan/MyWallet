
namespace MyWallet.Administration.Infrastructure.Multitenancy
{
    public interface IMultitenancyAccessor
    {
        TenancyContext GetTenancy();
    }
}
