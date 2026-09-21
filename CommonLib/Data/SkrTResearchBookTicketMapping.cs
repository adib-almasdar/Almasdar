using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class SkrTResearchBookTicketMapping
    {
        public int Id { get; set; }
        public int? ResearchId { get; set; }
        public string? TicketId { get; set; }

        public virtual SkrTResearchBook? Research { get; set; }
    }
}
