using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIC.WhiteboardApp.Data.Entities
{
    public class Board
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
