using System;

namespace MyWallet.Administration.Domain.Aggregation.Common
{
    public interface ICreationAt
    {
        DateTime? CreationAt { get; set; }
    }
}
