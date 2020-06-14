using Gingerbrich_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gingerbrich_backend.HelperModels
{
    public class ProductModel
    {

        public string name { get; set; }
        public string brand_name { get; set; }
        public string size { get; set; }
        public string color { get; set; }
        public string stock_left { get; set; }
        public List<SizeQuantity> sizesQuantity { get; set; }
        public List<Image> images { get; set; }
        public List<Category> categories { get; set; }
        public string discription { get; set; }
    }
}
