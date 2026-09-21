using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class SkrTResearchTypeLog
    {
        public int Id { get; set; }
        public int? ResearchTypeId { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual SkrMReseachType? ResearchType { get; set; }
    }
}
