using System;
using System.Collections.Generic;

namespace ISP
{
    public partial class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public string Description { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public int ManufacturerId { get; set; }
        public int CategoryId { get; set; }

        public virtual ItemCategories Category { get; set; }
        public virtual Manufacturers Manufacturer { get; set; }
    }
}
