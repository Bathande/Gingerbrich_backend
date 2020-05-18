﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gingerbrich_backend.Models
{
    public class Product_Discount
    {

        [ForeignKey("productId")]
        public int productId { get; set; } 
        public virtual Product product { get; set; }
        [ForeignKey("discountId")]
        public int discountId { get; set; }
        public virtual Discount discount { get; set; }
    }
}
