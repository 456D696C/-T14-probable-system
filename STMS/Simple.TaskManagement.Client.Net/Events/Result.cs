using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.TaskManagement.Events
{
    
    public class Result
    {
        public object Object { get; set; }

        public static Result<T> Create<T>(T @object) => new Result<T>(@object);

        public override string ToString()
        {
            return $"{GetType().Name}:{Object?.ToString() ?? "null"}";
        }
    }

    public class Result<T> : Result
    {
        public Result(T @object)
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
            return $"{nameof(Result<T>)}:{Object?.ToString() ?? "null"}";
        }
    }
}
