using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataObject.Models
{
    public class StorageDTO
    {
        public int CodeStorage { get; set; }
        [Required]
        [StringLength(20,ErrorMessage ="שם מחסן מכיל עד 20 תווים")]
        public string NameStorage { get; set; }
        [Required]
        public double? X { get; set; }
        [Required]
        public double? Y { get; set; }

        public int? transition { get; set; }

    }
}
