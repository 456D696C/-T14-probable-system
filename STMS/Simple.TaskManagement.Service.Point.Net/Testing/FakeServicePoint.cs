using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;



namespace Simple.TaskManagement.Testing
{
    public class FakeServicePoint
    {
        public static IUnityContainer Start()
        {
            return Bootstrapper.Start();
        }
    }
}
