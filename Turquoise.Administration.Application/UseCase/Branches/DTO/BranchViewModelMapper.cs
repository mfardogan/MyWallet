using AutoMapper;

namespace Turquoise.Administration.Application.UseCase.Branches.DTO
{
    using Turquoise.Administration.Domain.Aggregation.Branch;
    public sealed class BranchViewModelMapper : Profile
    {
        public BranchViewModelMapper()
        {
            CreateMap<Branch, BranchViewModel>();
            CreateMap<BranchViewModel, Branch>();
        }
    }
}
