using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataObject.Models
{
    public class ProductModelsDTO
    {
        public int CodeModel { get; set; }
        [Required]
        public int? CodeProduct { get; set; }
        [Required]
        public int? Size { get; set; }
        [Required]
        public int? CodeColor { get; set; }
        [Required]
        public int? CountInStock { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double? Price { get; set; }
        [Required]
        public int? Column { get; set; }
        [Required]
        public int? Position { get; set; }
        [Required]
        public int? Shelf { get; set; }
    }
}
