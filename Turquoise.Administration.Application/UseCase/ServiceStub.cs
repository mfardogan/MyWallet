using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Application.UseCase
{
    using Turquoise.Administration.Domain;
    using Turquoise.Administration.Domain.Abstraction;
    public class ServiceStub
    {
        private readonly Lazy<IIdentity> identity =
            new Lazy<IIdentity>(() => Dependency.Get<IIdentity>(),
                isThreadSafe: false);

        private readonly Lazy<ICacheService> cacheProvider =
            new Lazy<ICacheService>(()=> Dependency.Get<ICacheService>(), 
                isThreadSafe: false);

        /// <summary>
        /// User
        /// </summary>
        public IIdentity Identity => identity.Value;

        /// <summary>
        /// Cache provider
        /// </summary>
        public ICacheService DistributedMemoryCache => cacheProvider.Value;

        /// <summary>
        /// Completed task with data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public Task<T> Success<T>(T result) => Task.FromResult(result);

        /// <summary>
        /// Compted task as command
        /// </summary>
        /// <returns></returns>
        public Unit Success() => Unit.Value;

        /// <summary>
        /// Publish event
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        public async Task HandleEvent(INotification notification, CancellationToken cancellationToken = default)
        {
            await Dependency.Get<IMediator>().Publish(notification, cancellationToken);
        }
    }
}
