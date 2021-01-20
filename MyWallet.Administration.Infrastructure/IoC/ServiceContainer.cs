using Autofac;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MyWallet.Administration.Infrastructure.IoC
{
    using MyWallet.Administration.Domain.Abstraction;
    using MyWallet.Administration.Domain.Aggregation.Administrator;
    using MyWallet.Administration.Infrastructure.Multitenancy;
    using MyWallet.Administration.Infrastructure.Persistence;
    using MyWallet.Administration.Infrastructure.Persistence.Repository;

    public class ServiceContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            IConfigurationRoot root = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            builder.Register(x =>
            {
                var optsBuilder = new DbContextOptionsBuilder<MyDbContext>();
                optsBuilder.UseNpgsql(root.GetConnectionString("MyWalletLocal"));
                return new MyDbContext(optsBuilder.Options);
            }).InstancePerLifetimeScope();

            builder.RegisterType<MultitenancyHttpInterceptor>().As<IMultitenancyAccessor>().InstancePerLifetimeScope();
            builder.RegisterType<AdministratorRepository>().As<IAdministratorService>().InstancePerLifetimeScope();
            builder.RegisterType<UoW>().As<UnitOfWork>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
