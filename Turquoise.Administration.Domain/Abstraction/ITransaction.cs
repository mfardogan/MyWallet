using System;
using System.Threading.Tasks;

namespace Turquoise.Administration.Domain.Abstraction
{
    public interface ITransaction : IDisposable
    {
        Task RollbackAsync();
        Task CommitAsync();
    }
}
