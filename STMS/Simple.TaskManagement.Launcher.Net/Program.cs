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
            using (Run())
            {
                App.Main(); 
            }
        }


        public static async Task Run(int? timeToCompleteInSeconds=null)
        {

            await Task.Factory.StartNew(async () =>
            {
                if(timeToCompleteInSeconds > 0)
                await Task.Delay(TimeSpan.FromSeconds(timeToCompleteInSeconds.Value));
                //
                // Summary:
                //     Closes a process that has a user interface by sending a close message to its
                //     main window.
                //
                // Returns:
                //     true if the close message was successfully sent; false if the associated process
                //     does not have a main window or if the main window is disabled (for example if
                //     a modal dialog is being shown).
                //
                if (!Process.GetCurrentProcess().CloseMainWindow())
                    Process.GetCurrentProcess().Kill();

                return true;

            });

        }


        
    }
}
