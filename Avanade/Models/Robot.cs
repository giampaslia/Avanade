using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Models
{
    class Robot
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Secuency { get; set; }

        [Required]
        public Coordinates Coordinate { get; set; }

        [Required]
        [Column(TypeName = "varchar(1)")]
        public string Orientation { get; set; }

        [Required]
        [Column(TypeName = "Bool")]
        public string Lost { get; set; }
    }
}