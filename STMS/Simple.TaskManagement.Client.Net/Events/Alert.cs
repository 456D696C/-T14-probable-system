using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.TaskManagement.Events
{
    public class Alert
    {
        public object Object { get; set; }

        public static Alert<T> Create<T>(T @object) => new Alert<T>(@object);


        public override string ToString()
        {
            return $"{GetType().Name}:{Object?.ToString() ?? "null"}";
        }

    }

    public class Alert<T> : Alert
    {

        public Alert(T @object)
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
            return $"{nameof(Alert<T>)}:{Object?.ToString() ?? "null"}";
        }
    }
}
