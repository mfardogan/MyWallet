using MyWallet.Administration.Domain;
using System.Diagnostics;

namespace MyWallet.Administration.Infrastructure.Persistence
{
    public class BaseService
    {
        public MyDbContext DbContext { get; private set; }
        public BaseService()
        {
            DbContext = Dependency.Get<MyDbContext>();
            Debug.WriteLine(((object)DbContext).GetHashCode());
        }
    }
}
