using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Orders
    {
        public Orders()
        {
            ProductsOnOrder = new HashSet<ProductsOnOrder>();
        }

        public int CodeOrder { get; set; }
        public DateTime? DateOrder { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public int? ProductFile { get; set; }
        public int? Status { get; set; }
        public int? CodeCollector { get; set; }

        public virtual ICollection<ProductsOnOrder> ProductsOnOrder { get; set; }
    }
}
