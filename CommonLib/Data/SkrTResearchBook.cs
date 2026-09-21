using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class SkrTResearchBook
    {
        public SkrTResearchBook()
        {
            SkrTAttachments = new HashSet<SkrTAttachment>();
            SkrTNotes = new HashSet<SkrTNote>();
            SkrTNotesHistories = new HashSet<SkrTNotesHistory>();
            SkrTPeers = new HashSet<SkrTPeer>();
            SkrTResearchBookTicketMappings = new HashSet<SkrTResearchBookTicketMapping>();
        }

        public int ResearchId { get; set; }
        public string? Title { get; set; }
        public int? ResearchType { get; set; }
        public string? AssignedTo { get; set; }
        public string? CreatedBy { get; set; }
        public string? KeyWords { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Tags { get; set; }
        public string? Description { get; set; }
        public string? Branch { get; set; }
        public string? Status { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string? CustomResearchId { get; set; }

        public virtual SkrMReseachType? ResearchTypeNavigation { get; set; }
        public virtual ICollection<SkrTAttachment> SkrTAttachments { get; set; }
        public virtual ICollection<SkrTNote> SkrTNotes { get; set; }
        public virtual ICollection<SkrTNotesHistory> SkrTNotesHistories { get; set; }
        public virtual ICollection<SkrTPeer> SkrTPeers { get; set; }
        public virtual ICollection<SkrTResearchBookTicketMapping> SkrTResearchBookTicketMappings { get; set; }
    }
}
