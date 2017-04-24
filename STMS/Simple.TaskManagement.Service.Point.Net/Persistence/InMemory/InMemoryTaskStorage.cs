using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Simple.TaskManagement;

namespace Simple.TaskManagement.Persistence.InMemory
{
    public class InMemoryTaskStorage: Tasks. ITaskStorage
    {
        private readonly ConcurrentDictionary<string, DataTypes.Task> _Storage = new ConcurrentDictionary<string, DataTypes.Task>(StringComparer.InvariantCultureIgnoreCase);

        public Task<IEnumerable<DataTypes.Task>> Get(Func<DataTypes.Task, bool> filter)
        {
            return Task.FromResult(_Storage.Values.Where(task=>filter(task)));
        }

        public Task<DataTypes.Task> GetOrAdd(DataTypes.Task task, Func<string,DataTypes.Task> factory)
        {
            return Task.FromResult(_Storage.GetOrAdd(task.TaskId,factory));
        }

        public Task<DataTypes.Task> AddOrUpdate(DataTypes.Task task, Func<string, DataTypes.Task, DataTypes.Task> factory)
        {
            return Task.FromResult(_Storage.AddOrUpdate(task.TaskId,task,factory));
        }

    }
}
