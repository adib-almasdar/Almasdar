using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class SkrMNoteType
    {
        public SkrMNoteType()
        {
            SkrTNoteTypeLogs = new HashSet<SkrTNoteTypeLog>();
            SkrTNotes = new HashSet<SkrTNote>();
            SkrTNotesHistories = new HashSet<SkrTNotesHistory>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<SkrTNoteTypeLog> SkrTNoteTypeLogs { get; set; }
        public virtual ICollection<SkrTNote> SkrTNotes { get; set; }
        public virtual ICollection<SkrTNotesHistory> SkrTNotesHistories { get; set; }
    }
}
