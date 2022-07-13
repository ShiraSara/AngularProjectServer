using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ProductModels
    {
        public ProductModels()
        {
            ProductsOnOrder = new HashSet<ProductsOnOrder>();
        }

        public int CodeModel { get; set; }
        public int? CodeProduct { get; set; }
        public int? Size { get; set; }
        public int? CodeColor { get; set; }
        public int? CountInStock { get; set; }
        public double? Price { get; set; }
        public int? Column { get; set; }
        public int? Position { get; set; }
        public int? Shelf { get; set; }

        public virtual Colors CodeColorNavigation { get; set; }
        public virtual Products CodeProductNavigation { get; set; }
        public virtual ICollection<ProductsOnOrder> ProductsOnOrder { get; set; }
    }
}
