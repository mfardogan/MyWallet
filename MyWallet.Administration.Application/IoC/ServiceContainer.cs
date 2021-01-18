using Autofac;

namespace MyWallet.Administration.Application.IoC
{
    using MyWallet.Administration.Application.Service;
    using MyWallet.Administration.Domain.Abstraction;

    public class ServiceContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Rfc2898>().As<IPasswordHasher>().SingleInstance();
            builder.RegisterType<SaltFactory>().As<ISaltFactory>().SingleInstance();
            base.Load(builder);
        }
    }
}
