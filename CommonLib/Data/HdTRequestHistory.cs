using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class HdTRequestHistory
    {
        public int HistoryId { get; set; }
        public int? RequestId { get; set; }
        public int? RequestType { get; set; }
        public int? Branch { get; set; }
        public int? Department { get; set; }
        public string? RequesterName { get; set; }
        public string? RequesterId { get; set; }
        public string? CurrentRequestOwner { get; set; }
        public string? Title { get; set; }
        public string? Phone { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhoneNumber { get; set; }
        public string? CustomerRimnumber { get; set; }
        public string? FinanceNumber { get; set; }
        public string? Notes { get; set; }
        public string? History { get; set; }
        public int? Area { get; set; }
        public string? ShariaExpert { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public string? Question { get; set; }
        public int? Segment { get; set; }
        public int? Organisations { get; set; }
        public int? BusinessUnit { get; set; }
        public int? Division { get; set; }
        public int? Purpose { get; set; }
        public int? ShariaMode { get; set; }
        public int? SubjectOrInstrument { get; set; }
        public string? Principles { get; set; }
        public int? ProductApprovalId { get; set; }
        public int? ModifiedTawazunId { get; set; }
        public int? ProductConceptApprovalId { get; set; }
        public string? LegalAssignedTo { get; set; }
        public string? LegalStatus { get; set; }
        public int? SubSidiary { get; set; }
        public string? VertexQuestion { get; set; }
        public int? OriginalCategory { get; set; }
        public int? OriginalProduct { get; set; }
        public int? OriginalSubProduct { get; set; }
        public int? Category { get; set; }
        public int? Product { get; set; }
        public int? SubProduct { get; set; }
        public string? BranchName { get; set; }
        public string? DepartmentName { get; set; }

        public virtual HdMArea? AreaNavigation { get; set; }
        public virtual HdMBranch? BranchNavigation { get; set; }
        public virtual PcMBusinessUnit? BusinessUnitNavigation { get; set; }
        public virtual HdMCategory? CategoryNavigation { get; set; }
        public virtual HdMDepartment? DepartmentNavigation { get; set; }
        public virtual PcMDivision? DivisionNavigation { get; set; }
        public virtual PcMOrganisation? OrganisationsNavigation { get; set; }
        public virtual PcMSegment? OriginalCategoryNavigation { get; set; }
        public virtual PcMCategory? OriginalProductNavigation { get; set; }
        public virtual UscTVertex? OriginalSubProductNavigation { get; set; }
        public virtual HdMProduct? ProductNavigation { get; set; }
        public virtual PcMPurpose? PurposeNavigation { get; set; }
        public virtual HdTRequest? Request { get; set; }
        public virtual HdMRequestType? RequestTypeNavigation { get; set; }
        public virtual PcMSegment? SegmentNavigation { get; set; }
        public virtual PcMShariaMode? ShariaModeNavigation { get; set; }
        public virtual HdMSubProduct? SubProductNavigation { get; set; }
        public virtual PcMSubsidiary? SubSidiaryNavigation { get; set; }
        public virtual PcMSubjectOrInstrument? SubjectOrInstrumentNavigation { get; set; }
    }
}
