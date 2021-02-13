using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Application.UseCase.SurveyAnswers
{
    using Turquoise.Administration.Domain.Aggregation.SurveyAnswer;
    using Turquoise.Administration.Application.UseCase.SurveyAnswers.CQ;
    public partial class SurveyAnswerCQHandler :
        IRequestHandler<InsertSurveyAnswerCommand>,
        IRequestHandler<UpdateSurveyAnswerCommand>,
        IRequestHandler<DeleteSurveyAnswerCommand>
    {
        private readonly ISurveyAnsewerDAO dAO;
        private readonly ServiceProxy<ISurveyAnsewerDAO> service;
        public SurveyAnswerCQHandler()
        {
            var proxy = new ServiceProxy<ISurveyAnsewerDAO>();
            (service, dAO) = (proxy, proxy.DataAccessObject);
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(InsertSurveyAnswerCommand request, CancellationToken cancellationToken)
        {
            dAO.Insert(request.SurveyAnswerViewModel);
            await service.SaveAsync();
            return service.Success();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(UpdateSurveyAnswerCommand request, CancellationToken cancellationToken)
        {
            dAO.Update(request.SurveyAnswerViewModel);
            await service.SaveAsync();
            return service.Success();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(DeleteSurveyAnswerCommand request, CancellationToken cancellationToken)
        {
            dAO.Delete(request.SurveyAnswerId);
            await service.SaveAsync();
            return service.Success();
        }
    }
}
