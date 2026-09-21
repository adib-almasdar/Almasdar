using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class SkrTNotesHistory
    {
        public int HistoryId { get; set; }
        public int? NoteId { get; set; }
        public int? ResearchId { get; set; }
        public string? Note { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? Type { get; set; }

        public virtual SkrTNote? NoteNavigation { get; set; }
        public virtual SkrTResearchBook? Research { get; set; }
        public virtual SkrMNoteType? TypeNavigation { get; set; }
    }
}
