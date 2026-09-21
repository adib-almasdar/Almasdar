using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class LoMStatus
    {
        public LoMStatus()
        {
            LoTLeadTransactions = new HashSet<LoTLeadTransaction>();
            LoTLeads = new HashSet<LoTLead>();
        }

        public int Id { get; set; }
        public string? StatusName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; } = null!;
        public bool? IsDeleted { get; set; }
        public string? RoleBy { get; set; }
        public string? ValuePair { get; set; }

        public virtual ICollection<LoTLeadTransaction> LoTLeadTransactions { get; set; }
        public virtual ICollection<LoTLead> LoTLeads { get; set; }
    }
}
