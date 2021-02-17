using System;

namespace Turquoise.Administration.Domain.Aggregate.ChoiceGroup
{
    using Turquoise.Administration.Domain.Abstract;
    using Turquoise.Administration.Domain.Aggregate.Common;

    public interface IChoiceGroupDAO : IDataAccessObject,
        ICommand<ChoiceGroup, Guid>, 
        IQuery<ChoiceGroup, Guid>
    {
    }
}
