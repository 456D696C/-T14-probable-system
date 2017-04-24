using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;

using Reactive.EventAggregator;

namespace Simple.TaskManagement
{
    static partial class Bootstrapper
    {
        public static IUnityContainer RegisterTypes(this IUnityContainer container)
        {

            container
                .RegisterInstance<IEventAggregator>(new EventAggregator())
                .RegisterTypes(AllClasses
                .FromAssemblies(typeof(ViewModels.AboutThisViewModel).Assembly)
                .Where(t => t.Namespace == typeof(ViewModels.AboutThisViewModel).Namespace)
                .Where(t => t.Name.EndsWith("ViewModel"))
                .Where(t => t.IsAbstract == false)
                .Where(t => t.IsInterface == false),
                WithMappings.None,
                WithName.Default,
                WithLifetime.ContainerControlled);
            ;

            return container;
        }
    }
}
