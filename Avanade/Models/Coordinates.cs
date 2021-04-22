using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avanade.Models
{
    class Coordinates
    {
        [Required]
        [Column(TypeName = "varchar(2)")]
        public int X { get; set; }

        [Required]
        [Column(TypeName = "varchar(2)")]
        public int Y { get; set; }
    }
}