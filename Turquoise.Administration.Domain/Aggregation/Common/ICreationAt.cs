using System;

namespace Turquoise.Administration.Domain.Aggregation.Common
{
    public interface ICreationAt
    {
        DateTime? CreationAt { get; set; }
    }
}
