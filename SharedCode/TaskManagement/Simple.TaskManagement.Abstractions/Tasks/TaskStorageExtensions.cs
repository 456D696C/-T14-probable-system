using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.TaskManagement.Tasks
{
    public static class TaskStorageExtensions
    {

        public static Task<IEnumerable<DataTypes.Task>> Get(this ITaskStorage storage)
        {
            return storage.Get(_=>true);
        }

        public static Task<DataTypes.Task> AddOrUpdate(this ITaskStorage storage,  DataTypes.Task task)
        {
            return storage.AddOrUpdate(task,(key,entity)=>task);
        }
    }
}
