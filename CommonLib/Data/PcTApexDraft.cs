using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTApexDraft
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Purpose { get; set; }
        public string? ShariaMode { get; set; }
        public int? Type { get; set; }
        public string? Comments { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastmodifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? Status { get; set; }
        public string? ApproverEmails { get; set; }
        public string? ModificationReason { get; set; }
        public string? ModificationApprovalProof { get; set; }
        public string? ApexOwner { get; set; }
        public string? CustomApexId { get; set; }
        public string? AttachmentsJson { get; set; }
        public string? FatwaLinksJson { get; set; }
        public string? AlUsoolDocumentsJson { get; set; }
        public string? ApexRequestJson { get; set; }
        public string? ApexTransactionsJson { get; set; }
        public string? ApexStatusTransactionAttachmentsJson { get; set; }

        public int? ApexType { get; set; }

        public int? ApexCountryGroups { get; set; }
        public int? Organisation { get; set; }
    }
}
