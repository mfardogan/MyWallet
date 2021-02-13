using Autofac;

namespace Turquoise.Authentication.Application.IoC
{
    using Turquoise.Authentication.Application.Service;
    using Turquoise.Authentication.Domain.Abstraction;

    public class ServiceContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Rfc2898>().As<IPasswordHasher>().SingleInstance();
            builder.RegisterType<SaltFactory>().As<ISaltFactory>().SingleInstance();
            builder.RegisterType<Identity>().As<IIdentity>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
