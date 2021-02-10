using System;

namespace Turquoise.Administration.Domain.Aggregation.Survey
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Common;
    public interface ISurveyDAO : IDataAccessObject,
        ICommand<Survey, Guid>,
        IQuery<Survey, Guid>
    {
    }
}
