using Autofac;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Turquoise.Administration.Infrastructure.SQL.IoC
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Administrator;
    using Turquoise.Administration.Domain.Aggregation.Branch;
    using Turquoise.Administration.Domain.Aggregation.ChoiceGroup;
    using Turquoise.Administration.Domain.Aggregation.Survey;
    using Turquoise.Administration.Domain.Aggregation.SurveyAnswer;
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
            builder.RegisterType<AdministratorDAO>().As<IAdministratorDAO>().InstancePerLifetimeScope();
            builder.RegisterType<BranchDAO>().As<IBranchDAO>().InstancePerLifetimeScope();
            builder.RegisterType<SurveyDAO>().As<ISurveyDAO>().InstancePerLifetimeScope();
            builder.RegisterType<ChoiceGroupDAO>().As<IChoiceGroupDAO>().InstancePerLifetimeScope();
            builder.RegisterType<SurveyAnswerDAO>().As<ISurveyAnsewerDAO>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
