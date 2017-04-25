using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;

using Reactive.EventAggregator;

using Rebus.Handlers;
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
using Simple.TaskManagement.Events.Tasks;

using Simple.TaskManagement.Handlers;
using Simple.TaskManagement.Handlers.Tasks;

namespace Simple.TaskManagement
{
    static partial class Bootstrapper
    {
        public static IUnityContainer RegisterTypes(this IUnityContainer container)
        {

            container
                .RegisterInstance<IEventAggregator>(new EventAggregator())
                .RegisterType<IClientService, ClientService>(new ContainerControlledLifetimeManager())
                .RegisterTypes(AllClasses
                .FromAssemblies(typeof(ViewModels.AboutThisViewModel).Assembly)
                .Where(t => t.Namespace == typeof(ViewModels.AboutThisViewModel).Namespace)
                .Where(t => t.Name.EndsWith("ViewModel"))
                .Where(t => t.IsAbstract == false)
                .Where(t => t.IsInterface == false),
                WithMappings.None,
                WithName.Default,
                WithLifetime.ContainerControlled)
                .RegisterType(typeof(IHandleMessages<>), typeof(BridgeMessageHandler<>), "bridge")
                .RegisterType<IHandleMessages<TasksSearchOnCommentsReport>, TasksSearchOnCommentsReportMessageHandler>(name:nameof(TasksSearchOnCommentsReportMessageHandler))

                ;


            Configure.With(new UnityContainerAdapter(container))
               .Logging(l => l.ColoredConsole(minLevel: LogLevel.Debug))
               .UseFilesystem(Config.FileSystem.BaseDirectory, Config.Queues.FrontEnd)
               .Options(b => b.EnableMessageAuditing(Config.Queues.AuditFrontEnd))
               .Routing(r => r.TypeBased()
                                .MapAssemblyOf<Simple.TaskManagement.Contract>(a => a.CommandAndQueryTypes(), Config.Queues.MiddleEnd)
                                .MapAssemblyOf<Simple.TaskManagement.Contract>(a => a.ResultTypes(), Config.Queues.FrontEnd)
                               )
               .Start();
            

            return container;
        }
    }
}
