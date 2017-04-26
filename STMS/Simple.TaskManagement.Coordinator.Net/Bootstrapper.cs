using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;



using Rebus.Handlers;
using Simple.Query;
using Simple.Logging;
using Simple.TaskManagement.MessageHandlers;



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


using Simple.Rebus.Configuration;


namespace Simple.TaskManagement.Coordinator
{
    class Bootstrapper
    {
        public static IUnityContainer RegisterTypes(IUnityContainer container)
        {
            container
                .RegisterType<ISimpleLoggerFactory,Simple.Logging.ConsoleLoggerFactory>(new ContainerControlledLifetimeManager())
                .RegisterType<TaskCreatedSaga>()
                .RegisterType<SendCompletionNotificationMessageHandler>()
                .RegisterType<SendOverdueNotificationMessageHandler>()
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
               .UseFilesystem(Config.FileSystem.BaseDirectory, Config.Queues.BackEnd)
               .Options(b => b.EnableMessageAuditing(Config.Queues.AuditBackEnd))

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
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();

        }
    }
}
