using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class SkrTNote
    {
        public SkrTNote()
        {
            SkrTAttachments = new HashSet<SkrTAttachment>();
            SkrTNotesHistories = new HashSet<SkrTNotesHistory>();
        }

        public int NoteId { get; set; }
        public int? ResearchId { get; set; }
        public string? Note { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? Type { get; set; }
        public string? ReferenceLinks { get; set; }
        public string? Status { get; set; }
        public string? Tags { get; set; }

        public virtual SkrTResearchBook? Research { get; set; }
        public virtual SkrMNoteType? TypeNavigation { get; set; }
        public virtual ICollection<SkrTAttachment> SkrTAttachments { get; set; }
        public virtual ICollection<SkrTNotesHistory> SkrTNotesHistories { get; set; }
    }
}
