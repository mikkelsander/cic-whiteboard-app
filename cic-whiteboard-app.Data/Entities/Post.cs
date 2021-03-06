﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace CIC.WhiteboardApp.Data.Entities
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public int OffsetX { get; set; }
        public int OffsetY { get; set; }

        public DateTime CreatedTime { get; set; }
        public DateTime LastModifiedTime { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public ICollection<UserReaction> Reactions { get; set; }
        public ICollection<UserComment> Comments { get; set; }
    }
}
