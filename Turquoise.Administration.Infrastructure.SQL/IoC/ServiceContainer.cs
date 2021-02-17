using Autofac;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Turquoise.Administration.Infrastructure.SQL.IoC
{
    using Turquoise.Administration.Domain.Abstract;
    using Turquoise.Administration.Domain.Aggregate.Administrator;
    using Turquoise.Administration.Domain.Aggregate.Branch;
    using Turquoise.Administration.Domain.Aggregate.ChoiceGroup;
    using Turquoise.Administration.Domain.Aggregate.Survey;
    using Turquoise.Administration.Domain.Aggregate.SurveyAnswer;
    using Turquoise.Administration.Infrastructure.SQL.Service;

    public class ServiceContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x =>
            {
                IConfigurationRoot root = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

                var options = new DbContextOptionsBuilder<Database>();
                options.UseNpgsql(root.GetConnectionString("turquoise_ubuntu"));
                return new Database(options.Options);
            }).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUoW>().InstancePerLifetimeScope();
            builder.RegisterType<Transaction>().As<ITransaction>().InstancePerLifetimeScope();

            //Data access objects:
            builder.RegisterType<AdministratorDAO>().As<IAdministratorDAO>().InstancePerLifetimeScope();
            builder.RegisterType<BranchDAO>().As<IBranchDAO>().InstancePerLifetimeScope();
            builder.RegisterType<SurveyDAO>().As<ISurveyDAO>().InstancePerLifetimeScope();
            builder.RegisterType<ChoiceGroupDAO>().As<IChoiceGroupDAO>().InstancePerLifetimeScope();
            builder.RegisterType<SurveyAnswerDAO>().As<ISurveyAnsewerDAO>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
