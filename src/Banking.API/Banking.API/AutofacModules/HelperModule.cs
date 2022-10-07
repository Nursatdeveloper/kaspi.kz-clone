using Autofac;
using Banking.Application.Helpers;

namespace Banking.API.AutofacModules
{
    public class HelperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountHelper>()
                .As<IAccountHelper>()
                .InstancePerLifetimeScope();
        }
    }
}
