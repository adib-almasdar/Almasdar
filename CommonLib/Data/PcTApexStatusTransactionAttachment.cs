using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTApexStatusTransactionAttachment
    {
        public int AttachmentId { get; set; }
        public int? ApexId { get; set; }
        public int? TransactionId { get; set; }
        public string? Url { get; set; }
        public DateTime? UploadedDate { get; set; }
        public string? UploadedBy { get; set; }
        public string? Size { get; set; }
        public string? FileName { get; set; }
        public string? Status { get; set; }

        public virtual PcTApexTransaction? Transaction { get; set; }
    }
}
