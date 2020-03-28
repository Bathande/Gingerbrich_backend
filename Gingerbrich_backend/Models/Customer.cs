using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gingerbrich_backend.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        [EmailAddress]
        public string email { get; set; }
        
        public string address { get; set; }
        public int phone_number { get; set; }
        public string gender { get; set; }
        public string id_number { get; set; }
        public string name { get; set; }
        public string surname { get; set; }

    }
}
