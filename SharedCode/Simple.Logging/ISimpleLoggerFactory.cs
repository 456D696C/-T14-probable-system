using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.Logging
{
   
    /// <summary>
    /// Basic interface of a Simple logger factory.
    /// </summary>
    public interface ISimpleLoggerFactory
    {
        /// <summary>
        /// Gets a logger for the type <typeparamref name="T"/>
        /// </summary>
        ILog GetLogger<T>();
    }
}
