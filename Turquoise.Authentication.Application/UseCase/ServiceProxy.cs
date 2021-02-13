namespace Turquoise.Authentication.Application.UseCase
{
    using Turquoise.Authentication.Domain;
    using Turquoise.Authentication.Domain.Abstraction;

    public class ServiceProxy<TDAO> : ServiceStub where TDAO : IDataAccessObject
    {
        public ServiceProxy() => DataAccessObject = Dependency.Get<TDAO>();

        /// <summary>
        /// Aggregation service
        /// </summary>
        public TDAO DataAccessObject { get; }
    }
}
