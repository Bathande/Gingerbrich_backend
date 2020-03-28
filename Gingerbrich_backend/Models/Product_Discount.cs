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
        public int Product_id { get; set; }
        [Key]
        public int Discount_Id { get; set; }
        [ForeignKey("Product_id")]
        public virtual Product Product { get; set; }
        [ForeignKey("Discount_Id")]
        public virtual Discount Discount { get; set; }
    }
}
