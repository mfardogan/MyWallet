using MyWallet.Administration.Domain;
using MyWallet.Administration.Domain.Abstraction;
using System;

namespace MyWallet.Administration.Application.UseCase
{
    public class ServiceHandler<T> : Handler where T : IDbService
    {
        public T Service { get; }
        public UnitOfWork UoW => lazyUnitOfWorkInstance.Value;

        private readonly Lazy<UnitOfWork> lazyUnitOfWorkInstance =
            new Lazy<UnitOfWork>(() => Dependency.Get<UnitOfWork>());

        public ServiceHandler()
        {
            Service = Dependency.Get<T>();
        }
    }
}
