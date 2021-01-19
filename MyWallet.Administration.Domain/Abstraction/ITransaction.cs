using System.Threading.Tasks;

namespace MyWallet.Administration.Domain.Abstraction
{
    public interface ITransaction
    {
        Task RollbackAsync();
        Task CommitAsync();
    }
}
