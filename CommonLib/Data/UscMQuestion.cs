using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class UscMQuestion
    {
        public UscMQuestion()
        {
            HdTRequestVertexQuestionAnswers = new HashSet<HdTRequestVertexQuestionAnswer>();
        }

        public int QuestionId { get; set; }
        public string? QuestionEnglish { get; set; }
        public string? QuestionArabic { get; set; }
        public bool? IsMandatory { get; set; }
        public int? SubProductId { get; set; }
        public bool? Status { get; set; }
        public string? Qorder { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual UscTVertex? SubProduct { get; set; }
        public virtual ICollection<HdTRequestVertexQuestionAnswer> HdTRequestVertexQuestionAnswers { get; set; }
    }
}
