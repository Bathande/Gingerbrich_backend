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
        public int Customer_Id { get; set; }
        [Key]
        public int Notification_Id { get; set; }
        [ForeignKey("Customer_Id")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("Notification_Id")]
        public virtual Notification Notification { get; set; }
    }
}
