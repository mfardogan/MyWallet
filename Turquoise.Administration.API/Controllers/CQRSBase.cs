using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Turquoise.Administration.API.Controllers
{
    using Turquoise.Administration.Domain;
    public class CQRSBase : Base
    {
        private readonly IMediator mediator;
        public CQRSBase() => mediator = Dependency.Get<IMediator>();

        /// <summary>
        /// Command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [NonAction] public Task ExecuteCommandAsync(IRequest command) => mediator.Send(command);

        /// <summary>
        /// Query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        [NonAction] public Task<T> ExecuteQueryAsync<T>(IRequest<T> query) => mediator.Send(query);
    }
}
