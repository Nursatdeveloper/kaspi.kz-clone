using Autofac;
using Banking.Application.Commands;
using Banking.Application.Handlers.QueryHandlers;
using Banking.Application.Queries;
using Banking.Application.Responses;
using Banking.Core.Entities;
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

            /*
            builder.RegisterAssemblyTypes(typeof(IRequestHandler<DeleteEntityQuery<User>, DeletedResponse>).GetTypeInfo().Assembly,
                typeof(DeleteEntityHandler<User>).GetTypeInfo().Assembly);
            */

            builder.RegisterType<DeleteEntityHandler<User>>()
                .As<IRequestHandler<DeleteEntityQuery<User>, DeletedResponse>>();


            /*builder
                .RegisterAssemblyTypes(typeof(DeleteEntityQuery<User>).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(DeleteEntityHandler<User>)))
                .AsImplementedInterfaces();

            container.Register(typeof(IRequestHandler<,>), assemblies);
container.Register(typeof(IRequestHandler<,>), typeof(CreateAccessRequestHandler<,>));
            */

        }
    }
}
