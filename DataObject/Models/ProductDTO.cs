using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace DataObject.Models
{
   public class ProductDTO
    {
        public int CodeProduct { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "שם מכיל עד 20 תווים")]
        public string NameProduct { get; set; }
        [Required]
        public int? CodeGroup { get; set; }
        [Required]
        public int? CodeStorage { get; set; }
    }
}
