using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.TaskManagement
{
    namespace Commands.Comments
    {
        partial class AddOrUpdateCommentCommand { }
        partial class DeleteCommentCommand { }
    }

    namespace Queries.Comments
    {
        partial class CommentStatusQuery  { }
    }

    namespace Events.Comments
    {
        partial class CommentStatusReport { }
    }
}
