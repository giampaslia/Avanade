using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Models
{
    class Coordinates
    {
        [Required]
        [Column(TypeName = "varchar(2)")]
        public string X { get; set; }

        [Required]
        [Column(TypeName = "varchar(2)")]
        public string Y { get; set; }
    }
}