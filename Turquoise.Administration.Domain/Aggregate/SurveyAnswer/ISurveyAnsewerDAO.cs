using System;

namespace Turquoise.Administration.Domain.Aggregate.SurveyAnswer
{
    using Turquoise.Administration.Domain.Abstract;
    using Turquoise.Administration.Domain.Aggregate.Common;
    public interface ISurveyAnsewerDAO : IDataAccessObject,
        ICommand<SurveyAnswer, Guid>,
        IQuery<SurveyAnswer, Guid>
    {
    }
}
