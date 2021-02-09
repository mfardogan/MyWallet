using Autofac;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Turquoise.Administration.Infrastructure.SQL.IoC
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Administrator;
    using Turquoise.Administration.Infrastructure.SQL.Persistence;
    using Turquoise.Administration.Infrastructure.SQL.Persistence.Repository;

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

            builder.RegisterType<AdministratorRepository>().As<IAdministratorDAO>().InstancePerLifetimeScope();
            builder.RegisterType<UoW>().As<UnitOfWork>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
