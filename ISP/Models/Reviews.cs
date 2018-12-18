using System;
using System.Collections.Generic;

namespace ISP
{
    public partial class Reviews
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double? Rating { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }

        public virtual Users User { get; set; }
    }
}
