using MediatR;
using System;
using System.Threading.Tasks;

namespace MyWallet.Administration.Application.UseCase
{
    using MyWallet.Administration.Domain;
    using MyWallet.Administration.Domain.Abstraction;
    public class Handler
    {
        private readonly Lazy<IIdentity> lazyIdentity = 
            new Lazy<IIdentity>(()=> Dependency.Get<IIdentity>(),
                isThreadSafe: false);

        /// <summary>
        /// User
        /// </summary>
        public IIdentity Identity => lazyIdentity.Value;

        /// <summary>
        /// Completed task with data
        /// </summary>
        /// <typeparam name="P"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<P> Success<P>(P data) => Task.FromResult(data);

        /// <summary>
        /// Compted task as command
        /// </summary>
        /// <returns></returns>
        public Unit Success() => Unit.Value;

        /// <summary>
        /// Special case result
        /// </summary>
        /// <typeparam name="P"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public Task<P> SpecialCase<P>(P result) => Task.FromResult(result);
    }
}
