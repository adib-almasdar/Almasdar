using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class HdTRequestVertexQuestionAnswer
    {
        public int? RequestId { get; set; }
        public int? QuestionId { get; set; }
        public bool? Answer { get; set; }
        public int Id { get; set; }

        public virtual UscMQuestion? Question { get; set; }
        public virtual HdTRequest? Request { get; set; }
    }
}
