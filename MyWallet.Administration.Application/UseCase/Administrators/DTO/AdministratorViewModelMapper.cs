using AutoMapper;

namespace MyWallet.Administration.Application.UseCase.Administrators.DTO
{
    using MyWallet.Administration.Domain.Aggregation.Administrator;
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
