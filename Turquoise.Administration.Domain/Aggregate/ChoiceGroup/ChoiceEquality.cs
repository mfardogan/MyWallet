using System.Collections.Generic;

namespace Turquoise.Administration.Domain.Aggregate.ChoiceGroup
{
    public sealed class ChoiceEquality : IEqualityComparer<Choice>
    {
        bool IEqualityComparer<Choice>.Equals(Choice x, Choice y)
        {
            return x.Id.Equals(y.Id);
        }

        int IEqualityComparer<Choice>.GetHashCode(Choice obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
