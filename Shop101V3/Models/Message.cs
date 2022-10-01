using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop101V3.Models
{
    public class Message : BaseEntity
    {
        [Required, MaxLength(200)]
        public string SenderName { get; set; }
        [Required, MaxLength(200), EmailAddress]
        public string SenderEmail { get; set; }
        [Required]
        public string SenderPhone { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string MessageText { get; set; }
        public DateTime Date { get; set; }
    }
}
