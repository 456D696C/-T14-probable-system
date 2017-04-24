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

namespace Simple.TaskManagement.Coordinator
{
    class Bootstrapper
    {
        public static IUnityContainer RegisterTypes(IUnityContainer container)
        {
            container
                .RegisterType<ISimpleLoggerFactory, ConsoleLoggerFactory>(new ContainerControlledLifetimeManager())
                .RegisterType<TaskCreatedSaga>()
                .RegisterType<SendCompletionNotificationMessageHandler>()
                .RegisterType<SendOverdueNotificationMessageHandler>()
                ;

            return container;
        }
    }
}
