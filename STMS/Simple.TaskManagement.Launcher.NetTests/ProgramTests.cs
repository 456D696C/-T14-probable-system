using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.TaskManagement.Launcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Simple.TaskManagement.Launcher;
namespace Simple.TaskManagement.Launcher.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MainTest()
        {
            var expected =Program.Run().Wait(TimeSpan.FromSeconds(17));
            Assert.IsTrue(expected,"App killed from the task manager");
        }
    }
}