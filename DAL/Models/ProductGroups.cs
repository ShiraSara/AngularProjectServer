using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ProductGroups
    {
        public ProductGroups()
        {
            Products = new HashSet<Products>();
        }

        public int CodeGroups { get; set; }
        public string NaneGroups { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
