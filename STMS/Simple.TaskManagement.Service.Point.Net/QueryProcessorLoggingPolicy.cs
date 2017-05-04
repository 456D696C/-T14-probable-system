using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simple.Query;
using Simple.Logging;

namespace Simple.TaskManagement
{
    
    class QueryProcessorLoggingPolicy : IQueryProcessor
    {
        private readonly IQueryProcessor Decorated;
        private readonly ISimpleLoggerFactory LoggerFactory;

        public QueryProcessorLoggingPolicy(IQueryProcessor decorated, ISimpleLoggerFactory loggerFactory)
        {
            Decorated = decorated;
            LoggerFactory = loggerFactory;
        }

        public TResult Process<TResult>(IQuery<TResult> query)
        {
            LoggerFactory.GetLogger<IQuery<TResult>>().Info($"{ new { query } }".Replace("{", "{{").Replace("}", "}}"));
            var result = Decorated.Process(query);
            LoggerFactory.GetLogger<IQuery<TResult>>().Info($"{ new { query, result } }".Replace("{", "{{").Replace("}", "}}"));

            return result;
        }
    }

}
