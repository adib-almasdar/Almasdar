using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class LoTRedeemReward
    {
        public int Id { get; set; }
        public string? Offer { get; set; }
        public string? Status { get; set; }
        public string? RequesterName { get; set; }
        public string? RequestBy { get; set; }
        public DateTime? RequestDate { get; set; }
        public int? OfferId { get; set; }
        public string? AttachmentUrl { get; set; }
        public string? Comments { get; set; }
    }
}
