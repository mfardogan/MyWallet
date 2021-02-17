using Autofac;

namespace Turquoise.Administration.Infrastructure.Cache.IoC
{
    using Turquoise.Administration.Domain.Abstract;
    using Turquoise.Administration.Infrastructure.Cache.Service;

    public class ServiceContainer : Module
    {
        /// <summary>
        /// Load dependencies
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RedisMemoryCache>()
                .As<IDistributedMemory>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
