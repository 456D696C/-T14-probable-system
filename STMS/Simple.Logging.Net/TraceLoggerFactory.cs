using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Simple.Logging
{
    /// <summary>
    /// Logger factory that writes log statements using the <see cref="Trace"/> API
    /// </summary>
    public class TraceLoggerFactory : AbstractSimpleLoggerFactory
    {
        /// <summary>
        /// Gets a <see cref="TraceLogger"/>
        /// </summary>
        protected override ILog GetLogger(Type type)
        {
            return new TraceLogger(type);
        }

        class TraceLogger : ILog
        {
            readonly Type _type;

            public TraceLogger(Type type)
            {
                _type = type;
            }

            public void Debug(string message, params object[] objs)
            {
                Trace.TraceInformation(_type + ": " + message, objs);
            }

            public void Info(string message, params object[] objs)
            {
                Trace.TraceInformation(_type + ": " + message, objs);
            }

            public void Warn(string message, params object[] objs)
            {
                Trace.TraceWarning(_type + ": " + message, objs);
            }

            public void Error(Exception exception, string message, params object[] objs)
            {
                Trace.TraceError(_type + ": " + string.Format(message, objs) + Environment.NewLine + exception);
            }

            public void Error(string message, params object[] objs)
            {
                Trace.TraceError(_type + ": " + message, objs);
            }
        }
    }
}
