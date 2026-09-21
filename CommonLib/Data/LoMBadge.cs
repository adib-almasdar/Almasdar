using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class LoMBadge
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Points { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
