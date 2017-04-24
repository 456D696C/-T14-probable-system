using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using Rebus.Bus;
using Rebus.Handlers;
using Rebus.Sagas;


using Simple.TaskManagement.Messages;

namespace Simple.TaskManagement.MessageHandlers
{
    public class TaskCreatedSaga : Saga<TaskCreatedSaga.TaskCreatedSagaData>,
        IAmInitiatedBy<TaskCreated>,
        IAmInitiatedBy<TaskCompleted>,
        IAmInitiatedBy<TaskCanceled>,
        IHandleMessages<TaskSagaTimeout>
    {
        private readonly IBus Bus;

        public TaskCreatedSaga(IBus bus)
        {
            Bus = bus;
        }

        protected override void CorrelateMessages(ICorrelationConfig<TaskCreatedSagaData> config)
        {
            // events
            config.Correlate<TaskCreated>(message => message.TaskId, data => data.TaskId);
            config.Correlate<TaskCompleted>(message => message.TaskId, data => data.TaskId);
            config.Correlate<TaskCanceled>(message => message.TaskId, data => data.TaskId);

            // timeout
            config.Correlate<TaskSagaTimeout>(message => message.TaskId, data => data.TaskId);
        }


        public class TaskCreatedSagaData : SagaData
        {
            public string TaskId { get; set; }
            public string AssignedTo { get; set; }
            public DateTimeOffset RequiredByDate { get; set; }




            public bool TaskWasCompleted { get; set; }
            public bool TaskWasCanceled { get; set; }
        }



        public async Task Handle(TaskCreated message)
        {
            Console.WriteLine($"New trade created: {message.TaskId}");

            await MaybeTaskTimeout();

            Data.AssignedTo = message.AssignedTo;
            Data.RequiredByDate = message.RequiredByDate;

            await MaybeCompleteSaga();
        }

        public async Task Handle(TaskCompleted message)
        {
            Console.WriteLine($"Task completed: {message.TaskId}");

            await MaybeTaskTimeout();

            Data.TaskWasCompleted = true;

            await MaybeCompleteSaga();
        }

        public async Task Handle(TaskCanceled message)
        {
            Console.WriteLine($"Task canceled: {message.TaskId}");

            await MaybeTaskTimeout();

            Data.TaskWasCanceled = true;

            await MaybeCompleteSaga();
        }

        public async Task Handle(TaskSagaTimeout message)
        {
            Console.WriteLine($"Task timeout elapsed: {message.TaskId}");

            await Bus.SendLocal(new SendOverdueNotification() { TaskId = Data.TaskId });

            MarkAsComplete();
        }



        async Task MaybeTaskTimeout()
        {
            if (!IsNew) return;

            await Bus.Defer(TimeSpan.FromSeconds(10), new TaskSagaTimeout() { TaskId = Data.TaskId });
        }

        async Task MaybeCompleteSaga()
        {
            if (Data.TaskWasCanceled)
            {
                Console.WriteLine($"Task e {Data.TaskId} rejected... not doing anything");
                MarkAsComplete();
                return;
            }

            if (Data.TaskWasCompleted && Data.AssignedTo != null)
            {
                await Bus.SendLocal(new SendCompletionNotification() { TaskId = Data.TaskId });

                MarkAsComplete();
            }
        }

    }
}
