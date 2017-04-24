using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simple.TaskManagement.DataTypes;

namespace Simple.TaskManagement.Tasks
{
    public interface ITaskStorage
    {
        Task<IEnumerable<DataTypes.Task>> Get(Func<DataTypes.Task,bool> filter);
        Task<DataTypes.Task> GetOrAdd(DataTypes.Task task, Func<string, DataTypes.Task> factory);
        Task<DataTypes.Task> AddOrUpdate(DataTypes.Task task, Func<string, DataTypes.Task, DataTypes.Task> factory);
    }
}
