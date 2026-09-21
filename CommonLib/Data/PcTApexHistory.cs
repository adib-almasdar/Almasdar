using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTApexHistory
    {
        public int Id { get; set; }
        public int? ApexId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Purpose { get; set; }
        public string? ShariaMode { get; set; }
        public int? Type { get; set; }
        public string? Comments { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Status { get; set; }
        public string? ApproverEmails { get; set; }
        public string? ModificationApprovalProof { get; set; }
        public string? ModificationReason { get; set; }
        public int? ApexType { get; set; }
        public int? ApexCountryGroups { get; set; }
        public int? Organisation { get; set; }

        public virtual PcTApex? Apex { get; set; }
        public virtual PcMPurpose? PurposeNavigation { get; set; }
        public virtual PcMType? TypeNavigation { get; set; }
    }
}
