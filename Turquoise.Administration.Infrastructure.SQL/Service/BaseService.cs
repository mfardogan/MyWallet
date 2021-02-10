namespace Turquoise.Administration.Infrastructure.SQL.Service
{
    using Turquoise.Administration.Domain;
    public class BaseService
    {
        protected Database DatabaseContext { get; }
        public BaseService() => DatabaseContext = Dependency.Get<Database>();
    }
}
