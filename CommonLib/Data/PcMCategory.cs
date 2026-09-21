using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcMCategory
    {
        public PcMCategory()
        {
            HdTRequestHistories = new HashSet<HdTRequestHistory>();
            HdTRequests = new HashSet<HdTRequest>();
            PcTTawazunVarients = new HashSet<PcTTawazunVarient>();
            PcTTawazuns = new HashSet<PcTTawazun>();
            UscTOffers = new HashSet<UscTOffer>();
            UscTVertices = new HashSet<UscTVertex>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public int? Segment { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual PcMSegment? SegmentNavigation { get; set; }
        public virtual ICollection<HdTRequestHistory> HdTRequestHistories { get; set; }
        public virtual ICollection<HdTRequest> HdTRequests { get; set; }
        public virtual ICollection<PcTTawazunVarient> PcTTawazunVarients { get; set; }
        public virtual ICollection<PcTTawazun> PcTTawazuns { get; set; }
        public virtual ICollection<UscTOffer> UscTOffers { get; set; }
        public virtual ICollection<UscTVertex> UscTVertices { get; set; }
    }
}
