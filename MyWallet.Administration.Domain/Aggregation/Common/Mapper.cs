using AutoMapper;

namespace MyWallet.Administration.Domain.Aggregation.Common
{
    public abstract class Mapper : Profile
    {
        public Mapper() => ConfigureMapping();

        /// <summary>
        /// Configure mapping
        /// </summary>
        public abstract void ConfigureMapping();
    }
}
