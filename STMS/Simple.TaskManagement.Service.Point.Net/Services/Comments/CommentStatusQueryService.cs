using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simple.Query;
using Simple.TaskManagement.Tasks;
using Simple.TaskManagement.Queries.Comments;
using Simple.TaskManagement.Events.Comments;

namespace Simple.TaskManagement.Services.Comments
{
    class CommentStatusQueryService : IQueryHandler<CommentStatusQuery, CommentStatusReport>
    {
        private readonly ITaskStorage TaskStorage;

        public CommentStatusQueryService(ITaskStorage taskStorage)
        {
            TaskStorage = taskStorage;
        }

        public CommentStatusReport Handle(CommentStatusQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
