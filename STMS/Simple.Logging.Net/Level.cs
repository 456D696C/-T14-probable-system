using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Logging
{
    /// <summary>
    /// Log levels for <see cref="ConsoleLoggerFactory.ConsoleLogger" and <see cref="MinimalEventSource"/>/>.
    /// </summary>
    enum Level
    {
        /// <summary>
        /// Log statement of very low importance which is most likely only relevant in extreme debugging scenarios
        /// </summary>
        Debug = 0,

        /// <summary>
        /// Log statement of low importance to unwatched running systems which however can be very relevant when testing and debugging
        /// </summary>
        Information = 1,

        /// <summary>
        /// Log statement of fairly high importance - always contains relevant information on somewhing that may be a sign that something is wrong
        /// </summary>
        Warning = 2,

        /// <summary>
        /// Log statement of the highest importance - always contains relevant information on something that has gone wrong
        /// </summary>
        Error = 3,
    }
}
