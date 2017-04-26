using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

using Microsoft.Practices.Unity;

using System.IO;

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




using Rebus.Auditing.Messages;
using Rebus.Config;
using Rebus.DataBus;
using Rebus.DataBus.FileSystem;
using Rebus.Logging;
using Rebus.Persistence.FileSystem;
using Rebus.Persistence.InMem;
using Rebus.Routing.TypeBased;
using Rebus.Transport.FileSystem;
using Rebus.Unity;


using Rebus.Sagas;
using Rebus.Subscriptions;


using Simple.TaskManagement.Common;

using Simple.Rebus.Routing.TypeBased;
using Simple.Rebus.Configuration;
using Simple.Contract.Conventions;




namespace Simple.TaskManagement
{
    class Bootstrapper
    {
        public static IUnityContainer RegisterTypes(IUnityContainer container)
        {
            container
                .RegisterType<ISimpleLoggerFactory, Simple.Logging.ConsoleLoggerFactory>(new ContainerControlledLifetimeManager())
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
                 .RegisterType<IHandleMessages<AssignContactToTaskCommand>, AssignContactToTaskMessageHandler>(name: nameof(AssignContactToTaskCommand))
                 .RegisterType<IHandleMessages<UnassignContactFromTaskCommand>, UnassignContactFromTaskMessageHandler>(name: nameof(UnassignContactFromTaskCommand))
                 .RegisterType<IHandleMessages<AddOrUpdateCommentCommand>, AddOrUpdateCommentMessageHandler>(name: nameof(AddOrUpdateCommentMessageHandler))
                 .RegisterType<IHandleMessages<DeleteCommentCommand>, DeleteCommentMessageHandler>(name: nameof(DeleteCommentMessageHandler))

                ;
            return container;
        }


        public static IUnityContainer Start()
        {
            var container = Bootstrapper.RegisterTypes(new UnityContainer());
            

            DisplayContainerRegistrations(container);

            var bus = 
                Configure.With(new UnityContainerAdapter(container))
               .Logging(l => l.ColoredConsole(minLevel: LogLevel.Debug))
               .UseFilesystem(Config.FileSystem.BaseDirectory, Config.Queues.MiddleEnd)
               .Options(b => b.EnableMessageAuditing(Config.Queues.AuditMiddleEnd))
               .Routing(r => r.TypeBased()
                                .MapAssemblyOf<Simple.TaskManagement.Contract>(a => a.CommandAndQueryTypes(), Config.Queues.MiddleEnd)
                                .MapAssemblyOf<Simple.TaskManagement.Contract>(a => a.ResultTypes(), Config.Queues.FrontEnd)
                               )
           .Start();

           return container;
        }

        static void DisplayContainerRegistrations(IUnityContainer theContainer)
        {
            string regName, regType, mapTo, lifetime;
            Console.WriteLine("Container has {0} Registrations:",
                    theContainer.Registrations.Count());
            foreach (ContainerRegistration item in theContainer.Registrations)
            {
                regType = item.RegisteredType.Name;
                mapTo = item.MappedToType.Name;
                regName = item.Name ?? "[default]";
                lifetime = item.LifetimeManagerType.Name;
                if (mapTo != regType)
                {
                    mapTo = " -> " + mapTo;
                }
                else
                {
                    mapTo = string.Empty;
                }
                lifetime = lifetime.Substring(0, lifetime.Length - "LifetimeManager".Length);
                Console.WriteLine("+ {0}{1}  '{2}'  {3}", regType, mapTo, regName, lifetime);
            }

            Console.WriteLine();

        }
    }
}
