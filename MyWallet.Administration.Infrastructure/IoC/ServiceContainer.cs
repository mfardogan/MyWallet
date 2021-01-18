using Autofac;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyWallet.Administration.Infrastructure.Persistence;

namespace MyWallet.Administration.Infrastructure.IoC
{
    public class ServiceContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var configurationRoot = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

            builder.Register(x =>
            {
                var optsBuilder = new DbContextOptionsBuilder<MyDbContext>();
                optsBuilder.UseNpgsql(configurationRoot.GetConnectionString("MyWalletLocal"));
                return new MyDbContext(optsBuilder.Options);
            }).InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
