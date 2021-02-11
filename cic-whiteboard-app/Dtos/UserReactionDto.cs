using CIC.WhiteboardApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIC.WhiteboardApp.Dtos
{
    public class UserReactionDto
    {
        public int UserId { get; set; }
        public int PostId { get; set; }

        public ReactionType Type { get; set; }
    }
}
