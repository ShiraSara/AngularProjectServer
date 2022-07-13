using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataObject.Models
{
   public class OrdersDTO
    {
        public int CodeOrder { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? DateOrder { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? ExecutionDate { get; set; }
        [Required]
        public int? ProductFile { get; set; }
        [Required]
        public int? Status { get; set; }
        [Required]
        public int? CodeCollector { get; set; }

    }
}
