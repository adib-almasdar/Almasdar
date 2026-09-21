using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class HdTRequestQuestionAnswer
    {
        public int? RequestId { get; set; }
        public int? QuestionId { get; set; }
        public bool? Answer { get; set; }
        public int Id { get; set; }

        public virtual HdMQuestion? Question { get; set; }
        public virtual HdTRequest? Request { get; set; }
    }
}
