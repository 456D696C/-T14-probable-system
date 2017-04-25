using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Simple.TaskManagement.Persistence.InMemory
{
    class InMemoryTaskStorageMockup : InMemoryTaskStorage
    {
        public InMemoryTaskStorageMockup()
        {
            var mockups = new DataTypes.Mockups.MockupTasks().TaskList;

            foreach (var item in mockups)
            {
                base.AddOrUpdate(item,(key,entity)=>item);
            }
        }
    }
}
