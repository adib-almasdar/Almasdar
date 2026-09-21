using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class HdMProduct
    {
        public HdMProduct()
        {
            HdMSubProducts = new HashSet<HdMSubProduct>();
            HdTRequestHistories = new HashSet<HdTRequestHistory>();
            HdTRequests = new HashSet<HdTRequest>();
        }

        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        public string? Title { get; set; }
        public bool? Status { get; set; }
        public string? ArabicTitle { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? OrderNumber { get; set; }
        public bool? IsActive { get; set; }
        public virtual HdMCategory? Category { get; set; }
        public virtual ICollection<HdMSubProduct> HdMSubProducts { get; set; }
        public virtual ICollection<HdTRequestHistory> HdTRequestHistories { get; set; }
        public virtual ICollection<HdTRequest> HdTRequests { get; set; }
    }
}
