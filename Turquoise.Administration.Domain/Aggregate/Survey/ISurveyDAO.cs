using System;

namespace Turquoise.Administration.Domain.Aggregate.Survey
{
    using Turquoise.Administration.Domain.Abstract;
    using Turquoise.Administration.Domain.Aggregate.Common;
    public interface ISurveyDAO : IDataAccessObject,
        ICommand<Survey, Guid>,
        IQuery<Survey, Guid>
    {
    }
}
