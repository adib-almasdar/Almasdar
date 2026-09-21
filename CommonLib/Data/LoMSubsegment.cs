using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class LoMSubsegment
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? AttachmentUrl { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileSize { get; set; }
        public string? Description { get; set; }
    }
}
