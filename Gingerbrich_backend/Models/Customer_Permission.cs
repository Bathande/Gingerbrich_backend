using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gingerbrich_backend.Models
{
    public class Customer_Permission
    {
        [ForeignKey("permissionId")]
        public int permisssionId { get; set; }
        public virtual Permission permission { get; set; }
        [ForeignKey("customerId")]
        public int customerId { get; set; }
        public virtual Customer customer { get; set; }


    }
}
