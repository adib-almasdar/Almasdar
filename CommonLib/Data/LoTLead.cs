using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class LoTLead
    {
        public LoTLead()
        {
            LoTLeadTransactions = new HashSet<LoTLeadTransaction>();
            LoTPointsTransactions = new HashSet<LoTPointsTransaction>();
        }

        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? ContactNmber { get; set; }
        public string? EmailId { get; set; }
        public int? Region { get; set; }
        public string? PreferredTimeToCall { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? Spoc { get; set; }
        public string? Sources { get; set; }
        public string? InvestmentAmount { get; set; }
        public string? IncomeRange { get; set; }
        public bool? Flag { get; set; }
        public string? FlagComment { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? FlagCreatedDate { get; set; }
        public int? Agent { get; set; }
        public int? Status { get; set; }
        public bool? ExistingCustomer { get; set; }
        public string? StatusName { get; set; }
        public string? Product { get; set; }
        public int? Segment { get; set; }
        public int? SubSegment { get; set; }
        public int? Country { get; set; }
        public string? Acknowlegment { get; set; }
        public string? CustomLeadId { get; set; }
        public bool? UserConsent { get; set; }
        public string? AttachmentUrl { get; set; }

        public virtual LoMRegion? RegionNavigation { get; set; }
        public virtual LoMStatus? StatusNavigation { get; set; }
        public virtual ICollection<LoTLeadTransaction> LoTLeadTransactions { get; set; }
        public virtual ICollection<LoTPointsTransaction> LoTPointsTransactions { get; set; }
    }
}
