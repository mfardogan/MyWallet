using System;

namespace Turquoise.Administration.Domain.Aggregation.Choice
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Common;
    public interface IChoiceDAO : IDataAccessObject,
        ICommand<Choice, Guid>,
        IQuery<Choice, Guid>
    {
    }
}
