using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop101V3.Models
{
    public class ProductImage:BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Path { get; set; }
    }
}
