using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.TaskManagement;
using Simple.TaskManagement.Queries.Time;
using Simple.TaskManagement.Events.Time;


using Simple.TaskManagement.Testing;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.TaskManagement.Tests
{
    [TestClass()]
    public class QueryProcessorTests
    {
        [TestMethod()]
        public void QueryProcessorTest()
        {
            var container = FakeServicePoint.Start();

            var processor = container.Resolve<Simple.Query.IQueryProcessor>();

            Assert.IsNotNull(processor,$"Check the Boostapper.cs");
        }

        [TestMethod()]
        public void ProcessTest()
        {
            var container = FakeServicePoint.Start();

            var processor = container.Resolve<Simple.Query.IQueryProcessor>();

            Assert.IsNotNull(processor, "Check the Boostapper.cs");

            var time = processor.Process(new TimeQuery());

            Assert.IsNotNull(time, "Check the Boostapper.cs");


        }
    }
}