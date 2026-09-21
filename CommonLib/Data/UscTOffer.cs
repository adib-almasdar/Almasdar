using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class UscTOffer
    {
        public UscTOffer()
        {
            UscTOfferApproverAttachments = new HashSet<UscTOfferApproverAttachment>();
            UscTOfferSupportingAttachments = new HashSet<UscTOfferSupportingAttachment>();
            UscTOffersTransactions = new HashSet<UscTOffersTransaction>();
        }

        public int OfferId { get; set; }
        public string? OfferName { get; set; }
        public string? EmployeeName { get; set; }
        public int? Branch { get; set; }
        public int? RequestType { get; set; }
        public int? VertexId { get; set; }
        public string? ActiveOffers { get; set; }
        public int? SubSegment { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTill { get; set; }
        public string? Beneficiary { get; set; }
        public string? Description { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? Comments { get; set; }
        public string? Approvers { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Status { get; set; }
        public string? OfferStatus { get; set; }
        public string? BranchName { get; set; }
        public string? RequestTypeName { get; set; }
        public string? ThumbNailFileName { get; set; }
        public string? ThumbNailFileSize { get; set; }
        public string? ThumbNailFilePath { get; set; }
        public bool? IsDeleted { get; set; }
        public int? Country { get; set; }
        public int? Subsidiary { get; set; }
        public bool? IsActive { get; set; }
        public int? Segment { get; set; }
        public int? RootId { get; set; }
        public string? DisableBy { get; set; }
        public DateTime? DisableDate { get; set; }
        public DateTime? ModifiedStartDate { get; set; }
        public DateTime? ModifiedEndDate { get; set; }
        public string? CustumOfferId { get; set; }
        public string? DescriptionWithoutHtml { get; set; }

        public virtual HdMBranch? BranchNavigation { get; set; }
        public virtual HdMRequestType? RequestTypeNavigation { get; set; }
        public virtual PcMSegment? SegmentNavigation { get; set; }
        public virtual PcMCategory? SubSegmentNavigation { get; set; }
        public virtual UscTVertex? Vertex { get; set; }
        public virtual ICollection<UscTOfferApproverAttachment> UscTOfferApproverAttachments { get; set; }
        public virtual ICollection<UscTOfferSupportingAttachment> UscTOfferSupportingAttachments { get; set; }
        public virtual ICollection<UscTOffersTransaction> UscTOffersTransactions { get; set; }
    }
}
