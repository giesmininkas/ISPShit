using System;
using System.Collections.Generic;

namespace ISP
{
    public partial class ItemCategories
    {
        public ItemCategories()
        {
            InverseParent = new HashSet<ItemCategories>();
            Items = new HashSet<Items>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public virtual ItemCategories Parent { get; set; }
        public virtual ICollection<ItemCategories> InverseParent { get; set; }
        public virtual ICollection<Items> Items { get; set; }
    }
}
