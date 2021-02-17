using Autofac;
using System;

namespace Turquoise.Administration.Domain
{
    public sealed partial class Dependency
    {
        private Dependency() { }

        private static ILifetimeScope lifetimeScope;
        private static ContainerBuilder containerBuilder;

        private static readonly Lazy<Dependency> dependency =
            new Lazy<Dependency>(() => new Dependency(),
                isThreadSafe: true);

        /// <summary>
        /// Get shared singleton instance
        /// </summary>
        /// <returns></returns>
        public static Dependency Instance => dependency.Value;
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
