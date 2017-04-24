using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rebus.Bus;
using Rebus.Handlers;
using Simple.Query;

namespace Simple.TaskManagement.MessageHandlers.Queries
{
    class QueryMessageHandler<TQuery, TReport> : IHandleMessages<TQuery>
             where TQuery : IQuery<TReport>
    {

        private readonly IBus Bus;
        private readonly IQueryProcessor QueryProcessor;

        public QueryMessageHandler(IBus bus, IQueryProcessor queryProcessor)
        {
            Bus = bus;
            QueryProcessor = queryProcessor;
        }

        public Task Handle(TQuery message)
        {
            var report = QueryProcessor.Process(message);

            return Bus.Reply(report);
        }
    }
}
