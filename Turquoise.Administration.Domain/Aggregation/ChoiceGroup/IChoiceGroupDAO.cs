using System;

namespace Turquoise.Administration.Domain.Aggregation.ChoiceGroup
{
    using Turquoise.Administration.Domain.Aggregation.Common;

    public interface IChoiceGroupDAO :
        ICommand<ChoiceGroup, Guid>, 
        IQuery<ChoiceGroup, Guid>
    {
    }
}
