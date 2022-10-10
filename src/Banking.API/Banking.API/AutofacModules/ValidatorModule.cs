using Autofac;
using Banking.Application.Validators;

namespace Banking.API.AutofacModules
{
    public class ValidatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserValidator>()
                .As<IUserValidator>()
                .InstancePerLifetimeScope();
        }
    }
}
