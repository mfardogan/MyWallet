using Autofac;
using AutoMapper;

namespace MyWallet.Administration.Application.IoC
{
    using MyWallet.Administration.Application.Service;
    using MyWallet.Administration.Application.UseCase;
    using MyWallet.Administration.Domain.Abstraction;

    public class ServiceContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => new MapperConfiguration(x => x.AddMaps(typeof(ViewModel).Assembly)))
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


            builder.RegisterType<Rfc2898>().As<IPasswordHasher>().SingleInstance();
            builder.RegisterType<SaltFactory>().As<ISaltFactory>().SingleInstance();
            base.Load(builder);
        }
    }
}
