using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rebus.Time;

using Simple.Query;
using Simple.TaskManagement.Queries.Time;
using Simple.TaskManagement.Events.Time;

namespace Simple.TaskManagement.Services.Time
{
    public class TimeQueryService : IQueryHandler<TimeQuery, TimeReport>
    {
        public TimeReport Handle(TimeQuery query)
        {
            return new TimeReport()
            {
                Reference = query.Reference,
                Now = RebusTime.Now,
            };
        }
    }
}
