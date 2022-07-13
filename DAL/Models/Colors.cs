using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Colors
    {
        public Colors()
        {
            ProductModels = new HashSet<ProductModels>();
        }

        public int CodeColor { get; set; }
        public string NameColor { get; set; }

        public virtual ICollection<ProductModels> ProductModels { get; set; }
    }
}
