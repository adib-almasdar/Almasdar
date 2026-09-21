using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class UscTOfferSupportingAttachment
    {
        public int Id { get; set; }
        public int? OfferId { get; set; }
        public string? AttchmentTitle { get; set; }
        public string? AttachmentUrl { get; set; }
        public string? AttachmentSize { get; set; }
        public string? AttachmentPath { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }

        public virtual UscTOffer? Offer { get; set; }
    }
}
