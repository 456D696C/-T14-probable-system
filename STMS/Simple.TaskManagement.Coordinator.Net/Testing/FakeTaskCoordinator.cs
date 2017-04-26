using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;


using Simple.TaskManagement.Coordinator;

namespace Simple.TaskManagement.Testing
{
    public class FakeTaskCoordinator
    {
        public static IUnityContainer Start()
        {
            return Bootstrapper.Start();
        }
    }
}
