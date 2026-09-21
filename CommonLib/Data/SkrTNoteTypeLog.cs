using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class SkrTNoteTypeLog
    {
        public int Id { get; set; }
        public int? NoteTypeId { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual SkrMNoteType? NoteType { get; set; }
    }
}
