using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class SrMDocumentType
    {
        public SrMDocumentType()
        {
            PcTApexSupportingDocuments = new HashSet<PcTApexSupportingDocument>();
            SrTShariaDocumentHistories = new HashSet<SrTShariaDocumentHistory>();
            SrTShariaDocuments = new HashSet<SrTShariaDocument>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? ArabicTitle { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        public virtual ICollection<PcTApexSupportingDocument> PcTApexSupportingDocuments { get; set; }
        public virtual ICollection<SrTShariaDocumentHistory> SrTShariaDocumentHistories { get; set; }
        public virtual ICollection<SrTShariaDocument> SrTShariaDocuments { get; set; }
    }
}
