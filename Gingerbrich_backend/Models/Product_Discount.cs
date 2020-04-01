using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gingerbrich_backend.Models
{
    public class Product_Discount
    {
        [Key]
        public int ProductId { get; set; }
        [Key]
        public int DiscountId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [ForeignKey("DiscountId")]
        public virtual Discount Discount { get; set; }
    }
}
