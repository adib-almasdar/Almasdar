using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTApexComplyAttachment
    {
        public int Id { get; set; }
        public int? ApexId { get; set; }
        public string? AttachmentUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? Size { get; set; }
        public string? FileName { get; set; }
        public bool? IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
