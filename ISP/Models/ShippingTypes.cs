using System;
using System.Collections.Generic;

namespace ISP
{
    public partial class ShippingTypes
    {
        public ShippingTypes()
        {
            Bills = new HashSet<Bills>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }

        public virtual ICollection<Bills> Bills { get; set; }
    }
}
