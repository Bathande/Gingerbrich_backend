using Gingerbrich_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gingerbrich_backend.HelperModels
{
    public class ProductData
    {
        public List<Brand> brands { get; set; }
        public List<Category> categories { get; set; }
        public List<string> sizes { get; set; }
    }
}
