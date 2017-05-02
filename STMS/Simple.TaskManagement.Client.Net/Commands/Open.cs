using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.TaskManagement.Commands
{
   

    public class Open
    {
        public object Object { get; set; }

        public static Open<T> Create<T>(T @object) => new Open<T>(@object);


        public override string ToString()
        {
            return $"{GetType().Name}:{Object?.ToString() ?? "null"}";
        }

    }

    public class Open<T> : Open
    {

        public Open(T @object)
        {
            Object = @object;
        }

        public new T Object
        {
            get { return (T)base.Object; }
            set { base.Object = value; }
        }

        public override string ToString()
        {
            return $"{nameof(Open<T>)}:{Object?.ToString() ?? "null"}";
        }
    }
}
