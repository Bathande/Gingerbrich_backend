using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gingerbrich_backend.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string brand_name { get; set; }
        public string size { get; set; }
        public string color { get; set; }
        public string stock_left { get; set; }
        public string discription { get; set; }
    }
}
