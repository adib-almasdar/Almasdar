using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class UscTCommentsOffersTransaction
    {
        public int Id { get; set; }
        public int? OfferId { get; set; }
        public string? Attachment { get; set; }
        public int? TransactionId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? FileName { get; set; }
        public string? FileSize { get; set; }
        public string? FilePath { get; set; }

        public virtual UscTOffer? Offer { get; set; }
        public virtual UscTOffersTransaction? Transaction { get; set; }
    }
}
