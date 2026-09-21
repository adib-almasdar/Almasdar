using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class HdMArea
    {
        public HdMArea()
        {
            HdTRequestHistories = new HashSet<HdTRequestHistory>();
            HdTRequests = new HashSet<HdTRequest>();
        }

        public int AreaId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ArabicTitle { get; set; }
        public bool? Status { get; set; }
        public bool? IsActive { get; set; }
        public string? UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public string? ModifiedBy { get; set; }

        public virtual ICollection<HdTRequestHistory> HdTRequestHistories { get; set; }
        public virtual ICollection<HdTRequest> HdTRequests { get; set; }
    }
}
