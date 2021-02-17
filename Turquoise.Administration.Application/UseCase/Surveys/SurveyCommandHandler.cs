using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Turquoise.Administration.Application.UseCase.Surveys
{
    using Turquoise.Administration.Domain.Aggregation.Survey;
    using Turquoise.Administration.Application.UseCase.Surveys.CQ;
    public partial class SurveyCQHandler :
        IRequestHandler<InsertSurveyCommand>,
        IRequestHandler<UpdateSurveyCommand>,
        IRequestHandler<DeleteSurveyCommand>
    {
        private readonly ISurveyDAO dAO;
        private readonly ServiceProxy<ISurveyDAO> bussines;
        public SurveyCQHandler()
        {
            var proxy = new ServiceProxy<ISurveyDAO>();
            (bussines, dAO) = (proxy, proxy.DataAccessObject);
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(InsertSurveyCommand request, CancellationToken cancellationToken)
        {
            dAO.Insert(request.SurveyViewModel);
            await bussines.SaveAsync();
            return bussines.Success();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(UpdateSurveyCommand request, CancellationToken cancellationToken)
        {
            dAO.Update(request.SurveyViewModel);
            await bussines.SaveAsync();
            return bussines.Success();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(DeleteSurveyCommand request, CancellationToken cancellationToken)
        {
            dAO.Delete(request.SurveyId);
            await bussines.SaveAsync();
            return bussines.Success();
        }
    }
}
