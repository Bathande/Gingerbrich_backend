using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gingerbrich_backend.Models
{
    public class Product_Size
    {
        [ForeignKey("productId")]
        public virtual Product product { get; set; }
        [ForeignKey("sizeId")]
        public int sizeId { get; set; }
        public virtual Size size { get; set; }


    }
}
