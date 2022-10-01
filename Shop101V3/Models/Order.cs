using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop101V3.Models
{
    public class Order : BaseEntity
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        public string Description { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
