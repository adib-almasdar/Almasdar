using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class ElTBookMarkComment
    {
        public ElTBookMarkComment()
        {
            InverseReferMessage = new HashSet<ElTBookMarkComment>();
        }

        public int Id { get; set; }
        public int? ReferMessageId { get; set; }
        public int? BookId { get; set; }
        public string? Message { get; set; }
        public int? PageNumber { get; set; }
        public string? Highlight { get; set; }
        public DateTime? CommentDate { get; set; }
        public string? CommentBy { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ElTBook? Book { get; set; }
        public virtual ElTBookMarkComment? ReferMessage { get; set; }
        public virtual ICollection<ElTBookMarkComment> InverseReferMessage { get; set; }
    }
}
