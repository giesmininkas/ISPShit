using System;
using System.Collections.Generic;

namespace ISP
{
    public partial class CartsHasItems
    {
        public int CartId { get; set; }
        public int ItemId { get; set; }
        public int? Amount { get; set; }
    }
}
