using Autofac;

namespace Turquoise.Administration.Infrastructure.Cache.IoC
{
    using Turquoise.Administration.Domain.Abstraction;
    public class ServiceContainer : Module
    {
        /// <summary>
        /// Load dependencies
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RedisMemoryCache>().As<ICacheService>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
