using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.TaskManagement.Events
{
    public class Search
    {
        public object Object { get; set; }

        public static Search<T> Create<T>(T @object) => new Search<T>(@object);


        public override string ToString()
        {
            return $"{GetType().Name}:{Object?.ToString() ?? "null"}";
        }
    }


    public class Search<T> : Search
    {

        public Search(T @object)
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
            return $"{nameof(Search<T>)}:{Object?.ToString() ?? "null"}";
        }
    }
}
