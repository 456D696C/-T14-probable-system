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


using Simple.Rebus.Configuration;


namespace Simple.TaskManagement.Coordinator
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Bootstrapper.Start())
            {
                Console.WriteLine($@"
                    {typeof(Program).Namespace} up and runnig.
                    Press any key to stop!
                    "
                    );

                Console.ReadLine();

                Console.WriteLine($@"
                    {typeof(Program).Namespace} stopping...
                    "
                   );
            }

            Console.WriteLine($@"
                    {typeof(Program).Namespace} stopped.
                    Press any key to quit!
                    "
                    );

            Console.ReadLine();
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
