using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class SrTDocumentView
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string? UserEmail { get; set; }
        public int? PageNumber { get; set; }
        public DateTime? LastViewedDate { get; set; }

        public virtual SrTShariaDocument Document { get; set; } = null!;
    }
}
