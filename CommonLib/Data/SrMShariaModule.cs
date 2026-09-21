using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class SrMShariaModule
    {
        public SrMShariaModule()
        {
            SrMSubShariaModules = new HashSet<SrMSubShariaModule>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? ArabicTitle { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string? ThumbnailUrl { get; set; }

        public virtual ICollection<SrMSubShariaModule> SrMSubShariaModules { get; set; }
    }
}
