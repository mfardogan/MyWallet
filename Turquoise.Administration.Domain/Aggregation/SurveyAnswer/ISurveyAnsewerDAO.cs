using System;

namespace Turquoise.Administration.Domain.Aggregation.SurveyAnswer
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Common;
    public interface ISurveyAnsewerDAO : IDataAccessObject,
        ICommand<SurveyAnswer, Guid>,
        IQuery<SurveyAnswer, Guid>
    {
    }
}
