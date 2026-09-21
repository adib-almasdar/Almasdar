using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class UscTOfferMakerAttachment
    {
        public int Id { get; set; }
        public int? OfferId { get; set; }
        public string? AttchmentTitle { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? AttachmentUrl { get; set; }
        public string? FileName { get; set; }
        public string? FileSize { get; set; }
        public string? FilePath { get; set; }
        public int? TransationId { get; set; }
    }
}
