using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTApexFatwaLink
    {
        public int Id { get; set; }
        public int? ApexId { get; set; }
        public string? AttachmentUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? Title { get; set; }
        public bool? IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? Status { get; set; }
        public string? DocumentId { get; set; }
    }
}
