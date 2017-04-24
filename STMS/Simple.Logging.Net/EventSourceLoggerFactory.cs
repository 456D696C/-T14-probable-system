using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics.Tracing;



namespace Simple.Logging
{

    /// <summary>
    /// An <see cref="EventSource"/>:EventSource Tools like PerfView and Windows Performance Analyzer(formally XPERF) can be used immediately for (1) and(2) above.This blog is about doing(3).  You can also watch the video of me going through the steps below.
    /// </summary>
    sealed class MinimalEventSource : EventSource
    {
        public void Load(long ImageBase, string Name) { WriteEvent(1, ImageBase, Name); }


        public void TraceInformation(string message, params object[] objs)
        {
            WriteEvent(1,$"{Level.Information}:{message}", objs);
        }

        public void TraceWarning(string message, params object[] objs)
        {
            WriteEvent(1,$"{Level.Information}:{message}", objs);
        }

        public void TraceError(Exception exception, string message, params object[] objs)
        {
            WriteEvent(1,$"{Level.Error}:{message}",objs);
        }

        public void TraceError(string message, params object[] objs)
        {
            WriteEvent(1,$"{Level.Error}:{message}", objs);
        }

        public static MinimalEventSource Log = new MinimalEventSource();
    }

    /// <summary>
    /// Logger factory that writes log statements using the <see cref="Trace"/> API
    /// </summary>
    public class EventSourceLoggerFactory : AbstractSimpleLoggerFactory
    {
        /// <summary>
        /// Gets a <see cref="EventSourceLogger"/>
        /// </summary>
        protected override ILog GetLogger(Type type)
        {
            return new EventSourceLogger(type);
        }

        class EventSourceLogger : ILog
        {
            readonly Type _type;
            readonly MinimalEventSource _log;

            public EventSourceLogger(Type type)
            {
                _type = type;
                _log = MinimalEventSource.Log;
            }

            public void Debug(string message, params object[] objs)
            {
                _log.TraceInformation($"{_type}:{message}", objs);
            }

            public void Info(string message, params object[] objs)
            {
                _log.TraceInformation($"{_type}:{message}", objs);
            }

            public void Warn(string message, params object[] objs)
            {
                _log.TraceWarning($"{_type}:{message}", objs);
            }

            public void Error(Exception exception, string message, params object[] objs)
            {
                _log.TraceError($"{_type}:{string.Format(message, objs)}{Environment.NewLine}{exception}");
            }

            public void Error(string message, params object[] objs)
            {
                _log.TraceError($"{_type}:{message}", objs);
            }
        }
    }
}
