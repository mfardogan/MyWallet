namespace Turquoise.Administration.Infrastructure.SQL.Service
{
    using Turquoise.Administration.Domain;
    public class BaseService
    {
        public Database DbContext { get; private set; }
        public BaseService() => DbContext = Dependency.Get<Database>();
    }
}
