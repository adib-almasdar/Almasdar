using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class LoMReward
    {
        public int Id { get; set; }
        public string? RequiredPoints { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTill { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Status { get; set; }
        public string? Attachment { get; set; }
        public string? AttachmentUrl { get; set; }
    }
}
