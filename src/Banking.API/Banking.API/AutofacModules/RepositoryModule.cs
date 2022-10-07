
using Autofac;
using Banking.Infrastructure.Repositories;

namespace Banking.API.AutofacModules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
