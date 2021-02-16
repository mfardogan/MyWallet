using Autofac;

namespace Turquoise.Administration.Infrastructure.Cache.IoC
{
    using Turquoise.Administration.Domain.Abstraction;
    public class ServiceContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DistributedMemoryCache>().As<IDistributeMemoryCache>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
