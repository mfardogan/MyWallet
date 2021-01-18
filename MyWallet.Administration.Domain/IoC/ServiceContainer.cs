using Autofac;
using AutoMapper;
using MyWallet.Administration.Domain.Aggregation.Common;

namespace MyWallet.Administration.Domain.IoC
{
    public class ServiceContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => new MapperConfiguration(x => x.AddMaps(typeof(DbObject).Assembly)))
                .AsSelf()
                .SingleInstance();

            builder.Register(x =>
            {
                var context = x.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
