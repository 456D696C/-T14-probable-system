using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.TaskManagement.Events
{
    public class Selection
    {
        public object Object { get; set; }

        public static Selection<T> Create<T>(T @object) => new Selection<T>(@object);

        public override string ToString()
        {
            return $"{GetType().Name}:{Object?.ToString() ?? "null"}";
        }
    }

    public class Selection<T> : Selection
    {
        public Selection(T @object)
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
            return $"{nameof(Selection<T>)}:{Object?.ToString() ?? "null"}";
        }
    }
}
