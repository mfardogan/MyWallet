using System;

namespace Turquoise.Administration.Application.UseCase
{
    using Turquoise.Administration.Domain;
    using Turquoise.Administration.Domain.Abstraction;

    public class ServiceStub<TDao> : Stub where TDao : IDAO
    {
        private readonly Lazy<IUoW> lazyUoW;
        public ServiceStub() => (DataAccessObject, lazyUoW) =
            (Dependency.Get<TDao>(), new Lazy<IUoW>(
                () => Dependency.Get<IUoW>()));

        /// <summary>
        /// Aggregation service
        /// </summary>
        public TDao DataAccessObject { get; }

        /// <summary>
        /// Unit of work
        /// </summary>
        public IUoW UoW => lazyUoW.Value;
    }
}
