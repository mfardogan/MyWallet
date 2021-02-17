using Autofac;
using AutoMapper;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace Turquoise.Administration.Application.IoC
{
    using Turquoise.Administration.Domain.Abstract;
    using Turquoise.Administration.Application.Service;
    using Turquoise.Administration.Application.UseCase;

    public class ServiceContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
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

            builder.Register(x => new MapperConfiguration(x => x.AddMaps(typeof(ViewModel).Assembly))).AsSelf().SingleInstance();

            builder.RegisterType<Rfc2898>().As<IPasswordHasher>().SingleInstance();
            builder.RegisterType<SaltFactory>().As<ISaltFactory>().SingleInstance();
            builder.RegisterType<Identity>().As<IIdentity>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
