using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class UscTOfferSliderImage
    {
        public int Id { get; set; }
        public int? OfferId { get; set; }
        public string? AttachmentUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? FileName { get; set; }
        public string? FileSize { get; set; }
        public string? FilePath { get; set; }
    }
}
