using System;
using Turquoise.Administration.Domain.Aggregate.Branch;

namespace Turquoise.Administration.Application.UseCase.Branches.DTO
{
    public class BranchViewModel : EntityViewModelPersistent<Guid, Branch>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public uint ConcurrencyToken { get; set; }
    }
}
