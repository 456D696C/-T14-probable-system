using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using Microsoft.Practices.Unity;

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


namespace Simple.TaskManagement.Service.Point
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = Bootstrapper.RegisterTypes(new UnityContainer()))
            {

                DisplayContainerRegistrations(container);

                using (var bus = Configure.With(new UnityContainerAdapter(container))
               .Logging(l => l.ColoredConsole(minLevel: LogLevel.Debug))
               .UseFilesystem(Config.FileSystem.BaseDirectory, Config.Queues.MiddleEnd)
               .Options(b => b.EnableMessageAuditing(Config.Queues.AuditMiddleEnd))
               .Routing(r => r.TypeBased()
                                .MapAssemblyOf<Simple.TaskManagement.Contract>(a => a.CommandAndQueryTypes(), Config.Queues.MiddleEnd)
                                .MapAssemblyOf<Simple.TaskManagement.Contract>(a => a.ResultTypes(), Config.Queues.FrontEnd)
                               )
               .Start())
                {
                    Task.Run(async ()=> { await Task.Delay(TimeSpan.FromSeconds(3)); await Console.Out.WriteLineAsync($@"
                    {typeof(Program).Namespace} up and runnig.
                    Press any key to stop"); });
                    Console.ReadLine();
                };
            }
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
        }
    }
}
