using System;
using System.Collections.Generic;
using System.Reflection;
using Rebus.Routing.TypeBased;

namespace Simple.Rebus.Routing.TypeBased
{

    using Bulder = TypeBasedRouterConfigurationExtensions.TypeBasedRouterConfigurationBuilder;
    static class Extensions
    {
        public static Bulder MapAssemblyOf<T>(this Bulder builder, Func<Assembly, IEnumerable<Type>> selector, string destinationAddress)
        {
            foreach (var type in selector(typeof(T).Assembly))
            {
                builder.Map(messageType: type, destinationAddress: destinationAddress);
            }

            return builder;
        }
    }
}
