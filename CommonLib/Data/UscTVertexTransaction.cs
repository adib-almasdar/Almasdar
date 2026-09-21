using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class UscTVertexTransaction
    {
        public UscTVertexTransaction()
        {
            UscTCommentsVertexTransactionAttachments = new HashSet<UscTCommentsVertexTransactionAttachment>();
        }

        public int Id { get; set; }
        public int? VertexId { get; set; }
        public string? Comments { get; set; }
        public string? AttachmentUrl { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? FromPersonId { get; set; }
        public string? ToPersonId { get; set; }
        public string? TransactionByDisplayName { get; set; }
        public string? TransactionByRole { get; set; }

        public virtual UscTVertex? Vertex { get; set; }
        public virtual ICollection<UscTCommentsVertexTransactionAttachment> UscTCommentsVertexTransactionAttachments { get; set; }
    }
}
