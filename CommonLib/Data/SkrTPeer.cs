using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class SkrTPeer
    {
        public int Id { get; set; }
        public int? ResearchId { get; set; }
        public string? PeerEmailId { get; set; }

        public virtual SkrTResearchBook? Research { get; set; }
    }
}
