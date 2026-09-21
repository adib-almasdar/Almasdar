using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTTawazunTransaction
    {
        public PcTTawazunTransaction()
        {
            PcTTawazunCommentsAttachments = new HashSet<PcTTawazunCommentsAttachment>();
            PcTTawazunVarientApices = new HashSet<PcTTawazunVarientApex>();
        }

        public int Id { get; set; }
        public int? TawazunId { get; set; }
        public string? Action { get; set; }
        public string? Comment { get; set; }
        public string? TransactionBy { get; set; }
        public DateTime? Date { get; set; }
        public string? CheckerDraftStatus { get; set; }
        public string? FromPersonId { get; set; }
        public string? ToPersonId { get; set; }
        public string? TransactionByDisplayName { get; set; }
        public string? TransactionByRole { get; set; }

        public virtual PcTTawazun? Tawazun { get; set; }
        public virtual ICollection<PcTTawazunCommentsAttachment> PcTTawazunCommentsAttachments { get; set; }
        public virtual ICollection<PcTTawazunVarientApex> PcTTawazunVarientApices { get; set; }
    }
}
