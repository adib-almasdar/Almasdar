using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class HdMSubProduct
    {
        public HdMSubProduct()
        {
            HdMQuestions = new HashSet<HdMQuestion>();
            HdTRequestHistories = new HashSet<HdTRequestHistory>();
            HdTRequests = new HashSet<HdTRequest>();
        }

        public int SubProductId { get; set; }
        public int? ProductId { get; set; }
        public string? Title { get; set; }
        public int? CategoryId { get; set; }
        public string? ArabicTitle { get; set; }
        public string? DescriptionEnglish { get; set; }
        public string? DescriptionArabic { get; set; }
        public bool? Status { get; set; }
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
        public virtual HdMProduct? Product { get; set; }
        public virtual ICollection<HdMQuestion> HdMQuestions { get; set; }
        public virtual ICollection<HdTRequestHistory> HdTRequestHistories { get; set; }
        public virtual ICollection<HdTRequest> HdTRequests { get; set; }
    }
}
