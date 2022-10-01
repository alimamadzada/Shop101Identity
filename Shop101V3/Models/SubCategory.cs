using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop101V3.Models
{
    public class SubCategory : BaseEntity
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<Product> Products { get; set; }
    }
}
