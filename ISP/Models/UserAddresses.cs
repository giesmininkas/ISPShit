using System;
using System.Collections.Generic;

namespace ISP
{
    public partial class UserAddresses
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNr { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
    }
}
