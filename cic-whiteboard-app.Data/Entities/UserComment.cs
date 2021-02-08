using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace CIC.WhiteboardApp.Data.Entities
{
    public class UserComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime CreatedTime { get; set; }
        public DateTime LastModifiedTime { get; set; }

        public string Content { get; set; }
    }
}
