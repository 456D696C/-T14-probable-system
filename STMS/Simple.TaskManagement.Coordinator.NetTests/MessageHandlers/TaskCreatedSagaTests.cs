using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rebus.Testing;
using Simple.TaskManagement.Messages;
using Simple.TaskManagement.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.TaskManagement.MessageHandlers.Tests
{
    [TestClass()]
    public class TaskCreatedSagaTests
    {
        [TestMethod()]
        public void TaskCreatedSagaTest()
        {
            var bus = new FakeBus();
            using (var fixture = SagaFixture.For(() => new TaskCreatedSaga(bus)))
            {
                // perform test in here
                Assert.IsNotNull(fixture);
            }
        }

        [TestMethod()]
        public void HandleTaskCreatedTest()
        {
            var taskid = "task-id";
            var bus = new FakeBus();
            using (var fixture = SagaFixture.For(() => new TaskCreatedSaga(bus)))
            {
                // perform test in here
                fixture.Deliver(new TaskCreated()
                {
                    TaskId = taskid,
                });

                var myInstance = fixture.Data
                .OfType<TaskCreatedSaga.TaskCreatedSagaData>()
                .First(d => d.TaskId == taskid);
            }
        }
    }
}