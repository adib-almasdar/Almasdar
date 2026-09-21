using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class UscTOffersTransaction
    {
        public int Id { get; set; }
        public int? OfferId { get; set; }
        public string? TransactionComments { get; set; }
        public string? AttachmentUrl { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual UscTOffer? Offer { get; set; }
    }
}
