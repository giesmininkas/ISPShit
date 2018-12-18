using System;
using System.Collections.Generic;

namespace ISP
{
    public partial class WarehousesHasItems
    {
        public int WarehouseId { get; set; }
        public int ItemId { get; set; }
        public int? Amount { get; set; }

        public virtual Warehouses Warehouse { get; set; }
    }
}
