using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Logging
{
 

    /// <summary>
    /// Logger factory that writes log statements using the <see cref="Console"/> API
    /// </summary>
    public class ConsoleLoggerFactory : AbstractSimpleLoggerFactory
    {
        /// <summary>
        /// Gets a <see cref="ConsoleLogger"/>
        /// </summary>
        protected override ILog GetLogger(Type type)
        {
            return new ConsoleLogger(type);
        }

        class ConsoleLogger : ILog
        {
            readonly Type _type;

            public ConsoleLogger(Type type)
            {
                _type = type;
            }

            public void Debug(string message, params object[] objs)
            {
                Console.WriteLine($"{Level.Debug}:{_type}:{message}", objs);
            }

            public void Info(string message, params object[] objs)
            {
                Console.WriteLine($"{Level.Information}:{_type}:{message}", objs);
            }

            public void Warn(string message, params object[] objs)
            {
                Console.WriteLine($"{Level.Warning}:{_type}:{message}", objs);
            }

            public void Error(Exception exception, string message, params object[] objs)
            {
                Console.WriteLine($"{Level.Error}:{_type}:{string.Format(message, objs)}{Environment.NewLine}{exception}");
            }

            public void Error(string message, params object[] objs)
            {
                Console.WriteLine($"{Level.Error}:{_type}:{message}", objs);
            }

            
        }
    }
}
