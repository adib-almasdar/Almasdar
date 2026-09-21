using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class HdTStatusTransactionAttachment
    {
        public int AttachmentId { get; set; }
        public int? RequestId { get; set; }
        public string? Url { get; set; }
        public string? Name { get; set; }
        public int? TransactionId { get; set; }
        public DateTime? UploadedDate { get; set; }
        public string? UploadedBy { get; set; }
        public string? FileName { get; set; }

        public virtual HdTRequest? Request { get; set; }
        public virtual HdTRequestsStatusTransaction? Transaction { get; set; }
    }
}
