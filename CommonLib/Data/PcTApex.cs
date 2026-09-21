using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTApex
    {
        public PcTApex()
        {
            PcTApexHistories = new HashSet<PcTApexHistory>();
            PcTApexSupportingDocuments = new HashSet<PcTApexSupportingDocument>();
            PcTRequestApices = new HashSet<PcTRequestApex>();
            PcTTawazunVarientApices = new HashSet<PcTTawazunVarientApex>();
        }

        public int Id { get; set; }
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
        public int? ReferId { get; set; }
        public string? ApexOwner { get; set; }
        public string? CustomApexId { get; set; }
        public string? DescriptionWithoutHtml { get; set; }
        public int? RootApexId { get; set; }
        public string? ModificationApprovalProofName { get; set; }
        public bool? ComplyStatus { get; set; }
        public DateTime? CompliedDate { get; set; }
        public string? CompliedBy { get; set; }
        public string? ComplyComments { get; set; }
        public int? ApexType { get; set; }
        public int? ApexCountryGroups { get; set; }
        public int? Organisation { get; set; }

        public virtual PcMPurpose? PurposeNavigation { get; set; }
        public virtual PcMType? TypeNavigation { get; set; }
        public virtual ICollection<PcTApexHistory> PcTApexHistories { get; set; }
        public virtual ICollection<PcTApexSupportingDocument> PcTApexSupportingDocuments { get; set; }
        public virtual ICollection<PcTRequestApex> PcTRequestApices { get; set; }
        public virtual ICollection<PcTTawazunVarientApex> PcTTawazunVarientApices { get; set; }
    }
}
