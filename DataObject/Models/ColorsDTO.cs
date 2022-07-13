using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataObject.Models
{
    public class ColorsDTO
    {
        public int CodeColor { get; set; }
        [Required]
        [StringLength(10,ErrorMessage ="שם צבע מכיל 10 תווים מקסימום")]
        public string NameColor { get; set; }
    }
}
