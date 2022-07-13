using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataObject.Models
{
    public class ProductsOnOrderDTO
    {
        public int CodeProductsOnOrder { get; set; }
        [Required]
        public int? CodeOrder { get; set; }
        [Required]
        public int? CodeModel { get; set; }
        [Required]
        public int? Count { get; set; }
        [Required]
        public int? Status { get; set; }
    }
}
