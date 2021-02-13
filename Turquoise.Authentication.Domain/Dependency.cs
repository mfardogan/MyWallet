using Autofac;

namespace Turquoise.Authentication.Domain
{
    public sealed partial class Dependency
    {
        private Dependency() { }

        private static Dependency dependency;
        private static ILifetimeScope lifetimeScope;
        private static ContainerBuilder containerBuilder;
        private static readonly object _sync = new object();

        /// <summary>
        /// Get shared singleton instance
        /// </summary>
        /// <returns></returns>
        public static Dependency Instance
        {
            get
            {
                lock (_sync)
                {
                    if (dependency is null)
                    {
                        lock (_sync)
                        {
                            dependency = new Dependency();
                        }
                    }
                }
                return dependency;
            }
        }

        /// <summary>
        /// Set builder
        /// </summary>
        /// <param name="containerBuilder"></param>
        public Dependency SetContainerBuilder(ContainerBuilder containerBuilder)
        {
            Dependency.containerBuilder = containerBuilder;
            return this;
        }

        /// <summary>
        /// Set scope
        /// </summary>
        /// <param name="lifetimeScope"></param>
        public Dependency SetLifetimeScope(ILifetimeScope lifetimeScope)
        {
            Dependency.lifetimeScope = lifetimeScope;
            return this;
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public Dependency Register(Module module)
        {
            containerBuilder.RegisterModule(module);
            return this;
        }

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        public static TImplementation Get<TImplementation>() => lifetimeScope.Resolve<TImplementation>();
    }
}
