using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Logging
{

    /// <summary>
    /// If you intend to implement your own logging, you probably want to derive from this class and implement <seealso cref="GetLogger"/>
    /// </summary>
    public abstract class AbstractSimpleLoggerFactory:ISimpleLoggerFactory
    { 
        /// <inheritdoc />
        protected abstract ILog GetLogger(Type type);

        /// <inheritdoc />
        public ILog GetLogger<T>()
        {
            return GetLogger(typeof(T));
        }
    }
}
