using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIC.WhiteboardApp.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public int OffsetX { get; set; }
        public int OffsetY { get; set; }

        public DateTime CreatedTime { get; set; }
        public DateTime LastModifiedTime { get; set; }

        public int? UserId { get; set; }


        public ICollection<UserReactionDto> Reactions { get; set; }
        public ICollection<UserCommentDto> Comments { get; set; }
    }
}
