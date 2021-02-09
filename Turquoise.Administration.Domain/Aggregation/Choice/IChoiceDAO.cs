using System;

namespace Turquoise.Administration.Domain.Aggregation.Choice
{
    using Turquoise.Administration.Domain.Aggregation.Common;
    public interface IChoiceDAO :
        ICommand<Choice, Guid>,
        IQuery<Choice, Guid>
    {
    }
}
