
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.TaskManagement
{
    namespace Queries.Time
    {
        partial class TimeQuery
        {
            public string Reference { get; set; }
            public override string ToString() => new { Reference }.ToString();

        }
    }

    namespace Events.Time
    {
        partial class TimeReport
        {
            public string Reference { get; set; }
            public DateTimeOffset Now { get; set; }
            public override string ToString() => new { Now, Reference }.ToString();

        }
    }
}
