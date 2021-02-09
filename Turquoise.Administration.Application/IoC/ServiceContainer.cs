using Autofac;
using AutoMapper;
using MediatR.Extensions.Autofac.DependencyInjection;

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

#pragma warning disable CS0612 // Type or member is obsolete
            builder.AddMediatR(typeof(ViewModel).Assembly);
#pragma warning restore CS0612 // Type or member is obsolete

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
            builder.RegisterType<Identity>().As<IIdentity>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
