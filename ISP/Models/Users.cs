using System;
using System.Collections.Generic;

namespace ISP
{
    public partial class Users
    {
        public Users()
        {
            Bills = new HashSet<Bills>();
            Reviews = new HashSet<Reviews>();
            UserAddresses = new HashSet<UserAddresses>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Bills> Bills { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
        public virtual ICollection<UserAddresses> UserAddresses { get; set; }
    }
}
