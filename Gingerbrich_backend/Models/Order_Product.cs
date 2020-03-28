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
        [Key]
        public int Product_Id { get; set; }
        [Key]
        public int Customer_Id { get; set; }
        [ForeignKey("User_Id")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("Product_Id")]
        public virtual Product Product{ get; set; }
    }
}
