using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class HdMSyndAreWeAllowedQuestionValue
    {
        public int Id { get; set; }
        public string? Title { get; set; }
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
    }
}
