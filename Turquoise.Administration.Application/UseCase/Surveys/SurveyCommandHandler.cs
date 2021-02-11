using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Application.UseCase.Surveys
{
    using Turquoise.Administration.Domain.Aggregation.Survey;
    using Turquoise.Administration.Application.UseCase.Surveys.CQ;
    public partial class SurveyCQHandler :
        IRequestHandler<InsertSurvey>,
        IRequestHandler<UpdateSurvey>,
        IRequestHandler<DeleteSurvey>
    {
        private readonly ISurveyDAO dAO;
        private readonly ServiceProxy<ISurveyDAO> service;
        public SurveyCQHandler()
        {
            var proxy = new ServiceProxy<ISurveyDAO>();
            (service, dAO) = (proxy, proxy.DataAccessObject);
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(InsertSurvey request, CancellationToken cancellationToken)
        {
            Survey survey = request.SurveyViewModel;
            dAO.Insert(survey);
            await service.SaveAsync();
            return service.Success();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(UpdateSurvey request, CancellationToken cancellationToken)
        {
            Survey survey = request.SurveyViewModel;
            dAO.Update(survey);
            await service.SaveAsync();
            return service.Success();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(DeleteSurvey request, CancellationToken cancellationToken)
        {
            dAO.Delete(request.SurveyId);
            await service.SaveAsync();
            return service.Success();
        }
    }
}
