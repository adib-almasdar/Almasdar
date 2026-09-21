using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class LoTLeadTransaction
    {
        public int Id { get; set; }
        public int? LeadId { get; set; }
        public string? Comments { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? StatusId { get; set; }

        public virtual LoTLead? Lead { get; set; }
        public virtual LoMStatus? StatusNavigation { get; set; }
    }
}
