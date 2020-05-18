using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gingerbrich_backend.Models
{
    public class Order_Product
    {
        [ForeignKey("productId")]
        public int ProductId { get; set; }
        public virtual Product product { get; set; } 
        [ForeignKey("orderID")]
        public int OrderId { get; set; }
        public virtual Order order { get; set; }
     }
}