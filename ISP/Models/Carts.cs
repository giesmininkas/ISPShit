using System;
using System.Collections.Generic;

namespace ISP
{
    public partial class Carts
    {
        public int Id { get; set; }
        public int PackingMaterialId { get; set; }

        public virtual PackingMaterials PackingMaterial { get; set; }
    }
}
