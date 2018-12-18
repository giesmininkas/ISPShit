using System;
using System.Collections.Generic;

namespace ISP
{
    public partial class Manufacturers
    {
        public Manufacturers()
        {
            Items = new HashSet<Items>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Items> Items { get; set; }
    }
}
