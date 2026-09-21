using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class HdMRequestType
    {
        public HdMRequestType()
        {
            HdTRequestHistories = new HashSet<HdTRequestHistory>();
            HdTRequests = new HashSet<HdTRequest>();
            UscTOffers = new HashSet<UscTOffer>();
        }

        public int RequestTypeId { get; set; }
        public string? Title { get; set; }
        public string? TitleArabic { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? Role { get; set; }
        public int? OrderNumber { get; set; }
        public bool? IsActive { get; set; }
        public virtual ICollection<HdTRequestHistory> HdTRequestHistories { get; set; }
        public virtual ICollection<HdTRequest> HdTRequests { get; set; }
        public virtual ICollection<UscTOffer> UscTOffers { get; set; }
    }
}
