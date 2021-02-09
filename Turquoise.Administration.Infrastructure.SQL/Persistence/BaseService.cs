using System.Diagnostics;

namespace Turquoise.Administration.Infrastructure.SQL.Persistence
{
    using Turquoise.Administration.Domain;
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
