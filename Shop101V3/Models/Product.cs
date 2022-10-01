using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop101V3.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string Specifications { get; set; }
        public int Price { get; set; }
        public string MainImage { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public SubCategory SubCategory { get; set; }
        public int SubCategoryId { get; set; }
    }
}