using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class LoTPointsTransaction
    {
        public int Id { get; set; }
        public string? Users { get; set; }
        public string? Points { get; set; }
        public int? Lead { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual LoTLead? LeadNavigation { get; set; }
    }
}
