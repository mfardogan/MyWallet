using System;

namespace MyWallet.Administration.Application.UseCase
{
    using MyWallet.Administration.Domain;
    using MyWallet.Administration.Domain.Abstraction;

    public class ServiceHandler<T> : Handler where T : IDbService
    {
        private readonly Lazy<UnitOfWork> lazyUoW;
        public ServiceHandler() => (AggregationService, lazyUoW) =
            (Dependency.Get<T>(), new Lazy<UnitOfWork>(
                () => Dependency.Get<UnitOfWork>()));

        /// <summary>
        /// Aggregation service
        /// </summary>
        public T AggregationService { get; }

        /// <summary>
        /// Unit of work
        /// </summary>
        public UnitOfWork UoW => lazyUoW.Value;
    }
}
