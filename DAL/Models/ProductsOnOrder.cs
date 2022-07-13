using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ProductsOnOrder
    {
        public int CodeProductsOnOrder { get; set; }
        public int? CodeOrder { get; set; }
        public int? CodeModel { get; set; }
        public int? Count { get; set; }
        public int? Status { get; set; }

        public virtual ProductModels CodeModelNavigation { get; set; }
        public virtual Orders CodeOrderNavigation { get; set; }
    }
}
