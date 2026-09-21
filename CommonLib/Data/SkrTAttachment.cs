using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class SkrTAttachment
    {
        public int AttachmentId { get; set; }
        public int? ResearchId { get; set; }
        public string? Url { get; set; }
        public string? Name { get; set; }
        public int? NoteId { get; set; }
        public long? Size { get; set; }

        public virtual SkrTNote? Note { get; set; }
        public virtual SkrTResearchBook? Research { get; set; }
    }
}
