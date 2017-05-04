using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.ExceptionServices;

using Simple.Query;
using Simple.Logging;


namespace Simple.TaskManagement
{
    class QueryProcessorExceptionPolicy :IQueryProcessor
    {
        private readonly IQueryProcessor Decorated;
        private readonly ISimpleLoggerFactory LoggerFactory;

        public QueryProcessorExceptionPolicy(IQueryProcessor decorated, ISimpleLoggerFactory loggerFactory)
        {
            Decorated = decorated;
            LoggerFactory = loggerFactory;
        }

        public TResult Process<TResult>(IQuery<TResult> query)
        {

            try
            {
                return Decorated.Process(query);
            }
            catch (Exception exception)
            {
                LoggerFactory.GetLogger<IQuery<TResult>>().Error(exception, $"{new { query, Decorated }}".Replace("{", "{{").Replace("}", "}}"));
                ExceptionDispatchInfo.Capture(exception)?.Throw();
                throw;//make compiler happy
            }
        }
    }
}
