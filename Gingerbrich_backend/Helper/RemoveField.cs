using Gingerbrich_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gingerbrich_backend.Helper
{
    public static class RemoveField
    {
        //private static ModelContext _context;
 
        public static Customer removePassword(this Customer customer)
        {
            customer.password = null;
            return customer;
        }
    }
}
