using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataObject.Models
{
   public  class ProductGroupsDTO
    {
        public int CodeGroups { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "שם קבוצה מכיל עד 20 תווים")]
        public string NaneGroups { get; set; }
    }
}
