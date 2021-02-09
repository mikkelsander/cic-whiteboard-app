using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIC.WhiteboardApp.Dtos
{
    public class PostCreateDto
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public int OffsetX { get; set; }
        public int OffsetY { get; set; }

        public DateTime CreatedTime { get; set; }

        public int? UserId { get; set; }
    }
}
