using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTTawazun
    {
        public PcTTawazun()
        {
            PcTTawazunCommentsAttachments = new HashSet<PcTTawazunCommentsAttachment>();
            PcTTawazunHistories = new HashSet<PcTTawazunHistory>();
            PcTTawazunPackageAttachments = new HashSet<PcTTawazunPackageAttachment>();
            PcTTawazunPackageParentPackageTawazuns = new HashSet<PcTTawazunPackageParent>();
            PcTTawazunPackageParentParentTawauns = new HashSet<PcTTawazunPackageParent>();
            PcTTawazunPackageVarients = new HashSet<PcTTawazunPackageVarient>();
            PcTTawazunTransactions = new HashSet<PcTTawazunTransaction>();
            PcTTawazunVarientAlUsoolDocuments = new HashSet<PcTTawazunVarientAlUsoolDocument>();
            PcTTawazunVarientApices = new HashSet<PcTTawazunVarientApex>();
            PcTTawazunVarientAttachments = new HashSet<PcTTawazunVarientAttachment>();
            PcTTawazunVarientHistories = new HashSet<PcTTawazunVarientHistory>();
            PcTTawazunVarients = new HashSet<PcTTawazunVarient>();
        }

        public int Id { get; set; }
        public int? ProductApprovalId { get; set; }
        public int? ProductConceptApprovalId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? Status { get; set; }
        public string? OthersId { get; set; }
        public string? ProductVarient { get; set; }
        public int? Country { get; set; }
        public int? BusinessUnit { get; set; }
        public int? Divison { get; set; }
        public int? Type { get; set; }
        public int? Subject { get; set; }
        public string? OtherTawazunIds { get; set; }
        public string? Approver { get; set; }
        public string? CustomTawazunId { get; set; }
        public string? ShariasMode { get; set; }
        public int? SubSidiary { get; set; }
        public int? TawazunType { get; set; }
        public bool? Active { get; set; }
        public bool? IsDeleted { get; set; }
        public int? Purpose { get; set; }
        public bool? IsModified { get; set; }
        public string? EmployeeId { get; set; }
        public string? DepartmentName { get; set; }
        public int? OldTawazunTobeModified { get; set; }
        public int? RootId { get; set; }
        public string? DisableBy { get; set; }
        public DateTime? DisableDate { get; set; }
        public int? Segment { get; set; }
        public int? Subsegment { get; set; }
        public bool? Acknowledgement { get; set; }
        public int? TawazunCountryGroups { get; set; }

        public virtual PcMPurpose? PurposeNavigation { get; set; }
        public virtual PcMSegment? SegmentNavigation { get; set; }
        public virtual PcMSubsidiary? SubSidiaryNavigation { get; set; }
        public virtual PcMCategory? SubsegmentNavigation { get; set; }
        public virtual PcMTawazunType? TawazunTypeNavigation { get; set; }
        public virtual ICollection<PcTTawazunCommentsAttachment> PcTTawazunCommentsAttachments { get; set; }
        public virtual ICollection<PcTTawazunHistory> PcTTawazunHistories { get; set; }
        public virtual ICollection<PcTTawazunPackageAttachment> PcTTawazunPackageAttachments { get; set; }
        public virtual ICollection<PcTTawazunPackageParent> PcTTawazunPackageParentPackageTawazuns { get; set; }
        public virtual ICollection<PcTTawazunPackageParent> PcTTawazunPackageParentParentTawauns { get; set; }
        public virtual ICollection<PcTTawazunPackageVarient> PcTTawazunPackageVarients { get; set; }
        public virtual ICollection<PcTTawazunTransaction> PcTTawazunTransactions { get; set; }
        public virtual ICollection<PcTTawazunVarientAlUsoolDocument> PcTTawazunVarientAlUsoolDocuments { get; set; }
        public virtual ICollection<PcTTawazunVarientApex> PcTTawazunVarientApices { get; set; }
        public virtual ICollection<PcTTawazunVarientAttachment> PcTTawazunVarientAttachments { get; set; }
        public virtual ICollection<PcTTawazunVarientHistory> PcTTawazunVarientHistories { get; set; }
        public virtual ICollection<PcTTawazunVarient> PcTTawazunVarients { get; set; }
    }
}
