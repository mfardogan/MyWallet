using MyWallet.Administration.Domain.Aggregation.Common;

namespace MyWallet.Administration.Domain.Aggregation.Administrator
{
    public sealed class ViewModelMapper : Mapper
    {
        public override void ConfigureMapping()
        {
            CreateMap<Administrator, AdministratorViewModel>();
            CreateMap<AdministratorViewModel, Administrator>().ForMember(config => config.CreationAt, options => options.Ignore());
        }
    }
}
