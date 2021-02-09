using MediatR;
using System;
using System.Threading.Tasks;

namespace Turquoise.Administration.Application.UseCase
{
    using Turquoise.Administration.Domain;
    using Turquoise.Administration.Domain.Abstraction;
    public class Stub
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
