using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class SrTDocumentComment
    {
        public SrTDocumentComment()
        {
            InverseReferMessage = new HashSet<SrTDocumentComment>();
        }

        public int Id { get; set; }
        public int? ReferMessageId { get; set; }
        public int DocumentId { get; set; }
        public string? Message { get; set; }
        public int? PageNumber { get; set; }
        public string? Highlight { get; set; }
        public DateTime? CommentDate { get; set; }
        public string? CommentBy { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual SrTShariaDocument Document { get; set; } = null!;
        public virtual SrTDocumentComment? ReferMessage { get; set; }
        public virtual ICollection<SrTDocumentComment> InverseReferMessage { get; set; }
    }
}
