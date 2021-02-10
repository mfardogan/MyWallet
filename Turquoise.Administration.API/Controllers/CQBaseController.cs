using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Turquoise.Administration.API.Controllers
{
    using Turquoise.Administration.Domain;
    public class CQBaseController : BaseController
    {
        private readonly IMediator mediator;
        public CQBaseController()
        {
            mediator = Dependency.Get<IMediator>();
        }

        /// <summary>
        /// Command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [NonAction] 
        public virtual Task ExecuteCommandAsync(IRequest command) => mediator.Send(command);

        /// <summary>
        /// Query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        [NonAction] 
        public virtual Task<T> ExecuteQueryAsync<T>(IRequest<T> query) => mediator.Send(query);
    }
}
