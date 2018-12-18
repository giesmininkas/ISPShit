using System;
using System.Collections.Generic;

namespace ISP
{
    public partial class PackingMaterials
    {
        public PackingMaterials()
        {
            Carts = new HashSet<Carts>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }

        public virtual ICollection<Carts> Carts { get; set; }
    }
}
