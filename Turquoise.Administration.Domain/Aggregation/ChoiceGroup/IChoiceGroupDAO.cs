using System;

namespace Turquoise.Administration.Domain.Aggregation.ChoiceGroup
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Common;

    public interface IChoiceGroupDAO : IDataAccessObject,
        ICommand<ChoiceGroup, Guid>, 
        IQuery<ChoiceGroup, Guid>
    {
    }
}
