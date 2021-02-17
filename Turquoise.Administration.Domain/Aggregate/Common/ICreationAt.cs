using System;

namespace Turquoise.Administration.Domain.Aggregate.Common
{
    public interface ICreationAt
    {
        DateTime? CreationAt { get; set; }
    }
}
