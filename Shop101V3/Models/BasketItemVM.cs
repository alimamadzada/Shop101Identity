using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop101V3.Models
{
    public class BasketItemVM
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string MainImage { get; set; }
        public int Count { get; set; }
    }
}
