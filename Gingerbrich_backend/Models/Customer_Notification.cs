using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gingerbrich_backend.Models
{
    public class Customer_Notification
    {
        [ForeignKey("customerId")]
        public int customerId { get; set; }
        public virtual Customer custome { get; set; }
        [ForeignKey("notificationId")]
        public int notificationId { get; set; }
        public virtual Notification notification { get; set; }
    }
}
