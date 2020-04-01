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
        [Key]
        public int CustomerID { get; set; }
        [Key]
        public int NotificationID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("NotificationID")]
        public virtual Notification Notification { get; set; }
    }
}
