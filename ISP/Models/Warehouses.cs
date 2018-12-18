using System;
using System.Collections.Generic;

namespace ISP
{
    public partial class Warehouses
    {
        public Warehouses()
        {
            WarehousesHasItems = new HashSet<WarehousesHasItems>();
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public virtual ICollection<WarehousesHasItems> WarehousesHasItems { get; set; }
    }
}
