using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Storage
    {
        public Storage()
        {
            Products = new HashSet<Products>();
        }

        public int CodeStorage { get; set; }
        public string NameStorage { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public int? transition { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
