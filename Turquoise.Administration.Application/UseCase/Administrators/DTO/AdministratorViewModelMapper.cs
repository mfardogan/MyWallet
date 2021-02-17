using AutoMapper;

namespace Turquoise.Administration.Application.UseCase.Administrators.DTO
{
    using Turquoise.Administration.Domain.Aggregate.Administrator;
    public sealed class AdministratorViewModelMapper : Profile
    {
        public AdministratorViewModelMapper()
        {
            CreateMap<Administrator, AdministratorViewModel>();
            CreateMap<AdministratorViewModel, Administrator>()
                .ForMember(config => config.CreationAt, options => options.Ignore())
                .ForMember(config => config.Password, options => options.Ignore());
        }
    }
}
