using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gingerbrich_backend.Models
{
    public class Size
    {
        [Key]
        public int Id { get; set; }
        public string size { get; set; }
        public int left { get; set; }
    }
}
