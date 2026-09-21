using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class HdMBranch
    {
        public HdMBranch()
        {
            HdTRequestHistories = new HashSet<HdTRequestHistory>();
            HdTRequests = new HashSet<HdTRequest>();
            UscTOffers = new HashSet<UscTOffer>();
            UscTVertices = new HashSet<UscTVertex>();
        }

        public int BranchId { get; set; }
        public string? Title { get; set; }
        public bool? Status { get; set; }
        public string? ArabicTitle { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public string? ModifiedBy { get; set; }

        public virtual ICollection<HdTRequestHistory> HdTRequestHistories { get; set; }
        public virtual ICollection<HdTRequest> HdTRequests { get; set; }
        public virtual ICollection<UscTOffer> UscTOffers { get; set; }
        public virtual ICollection<UscTVertex> UscTVertices { get; set; }
    }
}
