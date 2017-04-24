using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;


using Simple.Query;


namespace Simple.Contract.Conventions
{
    public static class Convention
    {


        public static IEnumerable<Type> AllTypes(this Assembly assembly) => new[] { assembly }.AllTypes();
        public static IEnumerable<Type> ExportedTypes(this Assembly assembly) => new[] { assembly }.ExportedTypes();


        public static IEnumerable<Type> ContractTypes(this Assembly assembly) => new[] { assembly }.ContractTypes();
        public static IEnumerable<Type> CommandAndQueryTypes(this Assembly assembly) => new[] { assembly }.CommandAndQueryTypes();
        public static IEnumerable<Type> MessageTypes(this Assembly assembly) => new[] { assembly }.MessageTypes();
        public static IEnumerable<Type> CommandTypes(this Assembly assembly) => new[] { assembly }.CommandTypes();
        public static IEnumerable<Type> ResultTypes(this Assembly assembly) => new[] { assembly }.ResultTypes();
        public static IEnumerable<Type> QueryTypes(this Assembly assembly) => new[] { assembly }.QueryTypes();




        public static IEnumerable<Type> AllTypes(this IEnumerable<Assembly> assemblies)
           => assemblies.Select(assembly => assembly.GetExportedTypes()).CollectTypes();

        public static IEnumerable<Type> ExportedTypes(this IEnumerable<Assembly> assemblies)
            => assemblies.Select(assembly => assembly.GetExportedTypes()).CollectTypes();


        public static IEnumerable<Type> ContractTypes(this IEnumerable<Assembly> assemblies) =>
            new IEnumerable<Type>[]
            {
                assemblies.CommandTypes(),
                assemblies.QueryTypes(),
                assemblies.ResultTypes()
            }
            .CollectTypes();

        public static IEnumerable<Type> CommandAndQueryTypes(this IEnumerable<Assembly> assemblies) =>
            new IEnumerable<Type>[]
            {
                assemblies.CommandTypes(),
                assemblies.QueryTypes(),
            }
            .CollectTypes();

        public static IEnumerable<Type> MessageTypes(this IEnumerable<Assembly> assemblies) => assemblies.GetMessageTypes().Distinct();
        public static IEnumerable<Type> CommandTypes(this IEnumerable<Assembly> assemblies) => assemblies.GetCommandTypes().Distinct();
        public static IEnumerable<Type> ResultTypes(this IEnumerable<Assembly> assemblies) => assemblies.GetQueryTypes().Select(query => query.ResultType).Distinct();
        public static IEnumerable<Type> QueryTypes(this IEnumerable<Assembly> assemblies) => assemblies.GetQueryTypes().Select(query => query.QueryType).Distinct();





        public static IEnumerable<Type> GetMessageTypes(this IEnumerable<Assembly> contractAssemblies) =>
           from assembly in contractAssemblies
           from type in assembly.GetExportedTypes()
           where type.Name.EndsWith("Message")
           select type;


        public static IEnumerable<Type> GetCommandTypes(this IEnumerable<Assembly> contractAssemblies) =>
            from assembly in contractAssemblies
            from type in assembly.GetExportedTypes()
            where type.Name.EndsWith("Command") | type.Name.EndsWith("CommandMessage")
            select type;



        private static IEnumerable<QueryInfo> GetQueryTypes(this IEnumerable<Assembly> contractAssemblies) =>
          from assembly in contractAssemblies
          from type in assembly.GetExportedTypes()
          where QueryInfo.IsQuery(type)
          select new QueryInfo(type);


        //[DebuggerDisplay("{QueryType.Name,nq}")]
        private sealed class QueryInfo
        {
            public readonly Type QueryType;
            public readonly Type ResultType;

            public QueryInfo(Type queryType)
            {
                this.QueryType = queryType;
                this.ResultType = DetermineResultTypes(queryType).Single();
            }

            public static bool IsQuery(Type type) => DetermineResultTypes(type).Any();

            private static IEnumerable<Type> DetermineResultTypes(Type type) =>
                from interfaceType in type.GetInterfaces()
                where interfaceType.IsGenericType
                where interfaceType.GetGenericTypeDefinition() == typeof(IQuery<>)
                select interfaceType.GetGenericArguments()[0];
        }


        private static IEnumerable<Type> CollectTypes(this IEnumerable<IEnumerable<Type>> sources) =>
            sources.Aggregate(Enumerable.Empty<Type>(),
                            (buffer, types) => buffer.Concat(types),
                            buffer => buffer.Distinct());

    }
}
