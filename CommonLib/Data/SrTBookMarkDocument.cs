using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class SrTBookMarkDocument
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual SrTShariaDocument Document { get; set; } = null!;
    }
}
