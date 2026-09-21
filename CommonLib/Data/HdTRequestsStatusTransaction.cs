using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class HdTRequestsStatusTransaction
    {
        public HdTRequestsStatusTransaction()
        {
            HdTStatusTransactionAttachments = new HashSet<HdTStatusTransactionAttachment>();
        }

        public int TransactionId { get; set; }
        public int? RequestId { get; set; }
        public string? FromPersonId { get; set; }
        public string? Status { get; set; }
        public string? Comment { get; set; }
        public string? ToPersonId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string? TransactionBy { get; set; }
        public string? TransactionByDisplayName { get; set; }
        public string? TransactionByRole { get; set; }

        public virtual HdTRequest? Request { get; set; }
        public virtual ICollection<HdTStatusTransactionAttachment> HdTStatusTransactionAttachments { get; set; }
    }
}
