using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Simple.TaskManagement.Launcher
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {

            Process.Start(new ProcessStartInfo()
            {

                FileName = typeof(Client.Program).Assembly.CodeBase
            });


            //var service = Process.Start(new ProcessStartInfo()
            //{
            //    WindowStyle = ProcessWindowStyle.Maximized,
            //    FileName = typeof(Service.Point.Program).Assembly.CodeBase
            //});

            


           
            App.Main();
  
        }


       


        
    }
}
