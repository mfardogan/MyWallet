using Autofac;
using Microsoft.EntityFrameworkCore;
using MyWallet.Administration.Infrastructure.Persistence;

namespace MyWallet.Administration.Infrastructure.IoC
{
    public class ServiceContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            const string connectionString = "User ID=postgres;Password=admin;Server=localhost;Port=5432;Database=myWallet;Integrated Security=true;Pooling=true;";

            builder.Register(x =>
            {
                var optsBuilder = new DbContextOptionsBuilder<MyDbContext>();
                optsBuilder.UseNpgsql(connectionString);
                return new MyDbContext(optsBuilder.Options);
            }).InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
