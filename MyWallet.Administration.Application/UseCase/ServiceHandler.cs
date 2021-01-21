using System;

namespace MyWallet.Administration.Application.UseCase
{
    using MyWallet.Administration.Domain;
    using MyWallet.Administration.Domain.Abstraction;

    public class ServiceHandler<TDao> : Handler where TDao : IDAO
    {
        private readonly Lazy<UnitOfWork> lazyUoW;
        public ServiceHandler() => (DataAccessObject, lazyUoW) =
            (Dependency.Get<TDao>(), new Lazy<UnitOfWork>(
                () => Dependency.Get<UnitOfWork>()));

        /// <summary>
        /// Aggregation service
        /// </summary>
        public TDao DataAccessObject { get; }

        /// <summary>
        /// Unit of work
        /// </summary>
        public UnitOfWork UoW => lazyUoW.Value;
    }
}
