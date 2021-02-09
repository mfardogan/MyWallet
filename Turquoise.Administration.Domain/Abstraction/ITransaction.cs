using System;
using System.Threading.Tasks;

namespace MyWallet.Administration.Domain.Abstraction
{
    public interface ITransaction : IDisposable
    {
        Task RollbackAsync();
        Task CommitAsync();
    }
}
