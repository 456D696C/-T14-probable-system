using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;


using Simple.Query;

namespace Simple.TaskManagement
{
    sealed class QueryProcessor : IQueryProcessor
    {
        private readonly IUnityContainer Container;

        public QueryProcessor(IUnityContainer container)
        {
            Container = container;
        }

        public TResult Process<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = Container.Resolve(handlerType);

            return handler.Handle((dynamic)query);
        }
    }
}
