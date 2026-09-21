using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class TawazunCommentsAttachment
    {
        public int Id { get; set; }
        public string? AttachmentUrl { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileSize { get; set; }
        public int? TawazunId { get; set; }
        public int? TransactionId { get; set; }
        public string? UploadedBy { get; set; }
        public DateTime? UploadedDate { get; set; }

        public virtual PcTTawazun? Tawazun { get; set; }
        public virtual PcTTawazunTransaction? Transaction { get; set; }
    }
}
