using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIC.WhiteboardApp.Dtos
{
    public class UserCommentDto
    {
        public int Id { get; set; }

        public int PostId { get; set; }
        public int UserId { get; set; }

        public DateTime CreatedTime { get; set; }
        public DateTime LastModifiedTime { get; set; }

        public string Content { get; set; }
    }
}
