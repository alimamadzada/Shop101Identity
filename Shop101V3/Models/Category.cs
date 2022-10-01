using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop101V3.Models
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage ="Duzgun yazin"), MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public string ProductImage { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}