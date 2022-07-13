using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataObject.Models
{
    public class CollectorDTO
    {
        public int CodeCollector { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "שם מכיל עד 20 תווים")]
        public string NameCollector { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "שם משתמש מכיל עד 20 תווים")]
        public string Username { get; set; }
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
