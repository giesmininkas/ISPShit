using System;
using System.Collections.Generic;

namespace ISP
{
    public partial class Bills
    {
        public int Id { get; set; }
        public DateTime? BillingDate { get; set; }
        public string PaymentDate { get; set; }
        public int UsersId { get; set; }
        public int AddressId { get; set; }
        public int ShippingTypeId { get; set; }
        public int CartId { get; set; }
        public int PaymentTypeId { get; set; }

        public virtual PaymentTypes PaymentType { get; set; }
        public virtual ShippingTypes ShippingType { get; set; }
        public virtual Users Users { get; set; }
    }
}
