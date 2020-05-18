using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gingerbrich_backend.Models
{
    public class Product_Category
    {
        [ForeignKey("productId")]
        public int productId { get; set; }
        public virtual Product product { get; set; }
        [ForeignKey("categoryId")]
        public int categoryId { get; set; }
        public virtual Category category { get; set; }
    }
}
