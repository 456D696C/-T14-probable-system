using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

using Microsoft.Practices.Unity;

using Rebus.Handlers;
using Simple.Query;
using Simple.Logging;
using Simple.TaskManagement.Tasks;
using Simple.TaskManagement.Commands.Tasks;
using Simple.TaskManagement.Commands.Comments;
using Simple.TaskManagement.MessageHandlers.Queries;
using Simple.TaskManagement.MessageHandlers.Tasks;
using Simple.TaskManagement.MessageHandlers.Comments;
using Simple.TaskManagement.Persistence.InMemory;

namespace Simple.TaskManagement
{
    class Bootstrapper
    {
        public static IUnityContainer RegisterTypes(IUnityContainer container)
        {
            container
                .RegisterType<ISimpleLoggerFactory, ConsoleLoggerFactory>(new ContainerControlledLifetimeManager())
                .RegisterType<ITaskStorage, InMemoryTaskStorageMockup>(new ContainerControlledLifetimeManager())
                .RegisterType<IQueryProcessor, QueryProcessor>()
                .RegisterTypes(
                        types:typeof(Bootstrapper).Assembly.GetTypes()
                        .Where(type=>type.IsAbstract == false)
                        .Where(type=>type.GetInterfaces()
                        .Where(interfaceType=>interfaceType.IsGenericType)
                        .Where(interfaceType => interfaceType.GetGenericTypeDefinition()==typeof(IQueryHandler<,>))
                        .Any()),
                        getFromTypes:type=> WithMappings.FromAllInterfaces(type)
                        .Where(interfaceType => interfaceType.IsGenericType)
                        .Where(interfaceType => interfaceType.GetGenericTypeDefinition() == typeof(IQueryHandler<,>))
                        )

                .RegisterTypes(
                        types: typeof(Bootstrapper).Assembly.GetTypes()
                        .Where(type => type.IsAbstract == false)
                        .Where(type => type.GetInterfaces()
                        .Where(interfaceType => interfaceType.IsGenericType)
                        .Where(interfaceType => interfaceType.GetGenericTypeDefinition() == typeof(IQueryHandler<,>))
                        .Any())
                        .SelectMany(type=>type.GetInterfaces()
                        .Where(interfaceType => interfaceType.IsGenericType)
                        .Where(interfaceType => interfaceType.GetGenericTypeDefinition() == typeof(IQueryHandler<,>))
                        .Select(interfaceType=>typeof(QueryMessageHandler<,>).MakeGenericType(
                            interfaceType.GetGenericArguments()[0],
                            interfaceType.GetGenericArguments()[1])
                        )),
                        getFromTypes: type => WithMappings.FromAllInterfaces(type)
                         .Where(interfaceType => interfaceType.IsGenericType)
                         .Where(interfaceType => interfaceType.GetGenericTypeDefinition() == typeof(IHandleMessages<>)),

                        getName: type=>$"{type.GetGenericArguments()[0].Name}-{type.GetGenericArguments()[1].Name}-{type.Name}"
                        )

                 .RegisterType<IHandleMessages<AddOrUpdateTaskCommand>,AddOrUpdateTaskMessageHandler>(name:nameof(AddOrUpdateTaskMessageHandler))
                 .RegisterType<IHandleMessages<AddPeopleToTaskCommand>, AddPeopleToTaskMessageHandler>(name: nameof(AddPeopleToTaskMessageHandler))
                 .RegisterType<IHandleMessages<RemovePeopleFromTaskCommand>, RemovePeopleFromTaskMessageHandler>(name: nameof(RemovePeopleFromTaskMessageHandler))
                 .RegisterType<IHandleMessages<AddOrUpdateCommentCommand>, AddOrUpdateCommentMessageHandler>(name: nameof(AddOrUpdateCommentMessageHandler))
                 .RegisterType<IHandleMessages<DeleteCommentCommand>, DeleteCommentMessageHandler>(name: nameof(DeleteCommentMessageHandler))

                ;
            return container;
        }
    }
}
