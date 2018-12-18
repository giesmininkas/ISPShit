using System;
using System.Collections.Generic;

namespace ISP
{
    public partial class PaymentTypes
    {
        public PaymentTypes()
        {
            Bills = new HashSet<Bills>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }

        public virtual ICollection<Bills> Bills { get; set; }
    }
}
