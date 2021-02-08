using CIC.WhiteboardApp.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIC.WhiteboardApp.Data.Entities
{
    public class UserReaction
    {
        public int UserId { get; set; }
        public int PostId { get; set; }

        public ReactionType Type { get; set; }
    }
}
