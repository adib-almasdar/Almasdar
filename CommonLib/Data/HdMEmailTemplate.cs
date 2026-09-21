using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class HdMEmailTemplate
    {
        public int Id { get; set; }
        public bool? Status { get; set; }
        public string? TemplateName { get; set; }
        public string? EnglishTemplate { get; set; }
        public string? ArabicTemplate { get; set; }
        public string? EmailParameters { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
