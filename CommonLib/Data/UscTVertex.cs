using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class UscTVertex
    {
        public UscTVertex()
        {
            HdTRequestHistories = new HashSet<HdTRequestHistory>();
            HdTRequests = new HashSet<HdTRequest>();
            UscMQuestions = new HashSet<UscMQuestion>();
            UscTCommentsVertexTransactionAttachments = new HashSet<UscTCommentsVertexTransactionAttachment>();
            UscTFavouriteVertices = new HashSet<UscTFavouriteVertex>();
            UscTOffers = new HashSet<UscTOffer>();
            UscTOtherMediaAttachments = new HashSet<UscTOtherMediaAttachment>();
            UscTProductAttachments = new HashSet<UscTProductAttachment>();
            UscTProductCarts = new HashSet<UscTProductCart>();
            UscTSharedLeafletVertices = new HashSet<UscTSharedLeafletVertex>();
            UscTSliderImagesAttachments = new HashSet<UscTSliderImagesAttachment>();
            UscTSupportingDocuments = new HashSet<UscTSupportingDocument>();
            UscTVertexApprovers = new HashSet<UscTVertexApprover>();
            UscTVertexTransactions = new HashSet<UscTVertexTransaction>();
        }

        public int VertexId { get; set; }
        public string? VertexName { get; set; }
        public string? ShariaMode { get; set; }
        public string? Charge { get; set; }
        public string? Criteria { get; set; }
        public string? Rates { get; set; }
        public string? KeyBenefits { get; set; }
        public string? OtherBenefits { get; set; }
        public string? Loyality { get; set; }
        public bool? IsModifiedTawazun { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPublished { get; set; }
        public string? AssignedTo { get; set; }
        public string? LegalAssignedTo { get; set; }
        public string? LegalStatus { get; set; }
        public int? PreviousVertexId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Segment { get; set; }
        public string? Status { get; set; }
        public string? TumbnailImageUrl { get; set; }
        public int? Product { get; set; }
        public string? ThumbNailFileName { get; set; }
        public string? RequestType { get; set; }
        public string? EmployeeName { get; set; }
        public string? ThumbNailFilePath { get; set; }
        public string? FileLength { get; set; }
        public string? Description { get; set; }
        public int? ChargesId { get; set; }
        public int? RateId { get; set; }
        public int? CriteriaId { get; set; }
        public int? LoyaltyId { get; set; }
        public int? SubSegment { get; set; }
        public int? Department { get; set; }
        public int? Branch { get; set; }
        public string? CustomVertexId { get; set; }
        public string? ArabicCharges { get; set; }
        public string? ArabicRate { get; set; }
        public string? ArabicCriteria { get; set; }
        public string? ArabicLoyalty { get; set; }
        public string? ArabicKeyBenefits { get; set; }
        public string? ArabicOtherBenefits { get; set; }
        public int? TawazunId { get; set; }
        public bool? IsDeleted { get; set; }
        public int? Country { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? BranchName { get; set; }
        public string? DepartmentName { get; set; }
        public int? SubSidiary { get; set; }
        public int? RootId { get; set; }
        public string? DisableBy { get; set; }
        public DateTime? DisableDate { get; set; }
        public string? ChargeEnglishWithoutHtml { get; set; }
        public string? CriteriaEnglishWithoutHtml { get; set; }
        public string? RateEnglishWithoutHtml { get; set; }
        public string? LoyalityEnglishWithoutHtml { get; set; }
        public string? ChargeArabicWithoutHtml { get; set; }
        public string? CriteriaArabicWithoutHtml { get; set; }
        public string? RateArabicWithoutHtml { get; set; }
        public string? LoyalityArabicWithoutHtml { get; set; }
        public string? KeyBenefitsEnglishWithoutHtml { get; set; }
        public string? OtherBenefitsEnglishWithoutHtml { get; set; }
        public string? KeyBenefitsArabicWithoutHtml { get; set; }
        public string? OtherBenefitsArabicWithoutHtml { get; set; }
        public string? DescriptionWithoutHtml { get; set; }
        public bool? ComplyStatus { get; set; }
        public DateTime? CompliedDate { get; set; }
        public string? CompliedBy { get; set; }
        public string? ComplyComments { get; set; }

        public virtual HdMBranch? BranchNavigation { get; set; }
        public virtual UscMCharge? Charges { get; set; }
        public virtual PcMOrganisation? CountryNavigation { get; set; }
        public virtual UscMCriterion? CriteriaNavigation { get; set; }
        public virtual HdMDepartment? DepartmentNavigation { get; set; }
        public virtual UscMLoyalty? Loyalty { get; set; }
        public virtual UscMRate? Rate { get; set; }
        public virtual PcMSegment? SegmentNavigation { get; set; }
        public virtual PcMCategory? SubSegmentNavigation { get; set; }
        public virtual PcTTawazunVarient? Tawazun { get; set; }
        public virtual ICollection<HdTRequestHistory> HdTRequestHistories { get; set; }
        public virtual ICollection<HdTRequest> HdTRequests { get; set; }
        public virtual ICollection<UscMQuestion> UscMQuestions { get; set; }
        public virtual ICollection<UscTCommentsVertexTransactionAttachment> UscTCommentsVertexTransactionAttachments { get; set; }
        public virtual ICollection<UscTFavouriteVertex> UscTFavouriteVertices { get; set; }
        public virtual ICollection<UscTOffer> UscTOffers { get; set; }
        public virtual ICollection<UscTOtherMediaAttachment> UscTOtherMediaAttachments { get; set; }
        public virtual ICollection<UscTProductAttachment> UscTProductAttachments { get; set; }
        public virtual ICollection<UscTProductCart> UscTProductCarts { get; set; }
        public virtual ICollection<UscTSharedLeafletVertex> UscTSharedLeafletVertices { get; set; }
        public virtual ICollection<UscTSliderImagesAttachment> UscTSliderImagesAttachments { get; set; }
        public virtual ICollection<UscTSupportingDocument> UscTSupportingDocuments { get; set; }
        public virtual ICollection<UscTVertexApprover> UscTVertexApprovers { get; set; }
        public virtual ICollection<UscTVertexTransaction> UscTVertexTransactions { get; set; }
    }
}
