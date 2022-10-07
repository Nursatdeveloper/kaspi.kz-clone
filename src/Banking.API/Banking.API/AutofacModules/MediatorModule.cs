using Autofac;
using Banking.Application.Commands;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using System.Reflection;

namespace Banking.API.AutofacModules
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            builder.RegisterMediatR(typeof(Program).Assembly);

            builder.RegisterAssemblyTypes(typeof(CreateUserCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

        }
    }
}
