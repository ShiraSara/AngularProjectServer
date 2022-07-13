using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Products
    {
        public Products()
        {
            ProductModels = new HashSet<ProductModels>();
        }

        public int CodeProduct { get; set; }
        public string NameProduct { get; set; }
        public int? CodeGroup { get; set; }
        public int? CodeStorage { get; set; }

        public virtual ProductGroups CodeGroupNavigation { get; set; }
        public virtual Storage CodeStorageNavigation { get; set; }
        public virtual ICollection<ProductModels> ProductModels { get; set; }
    }
}
