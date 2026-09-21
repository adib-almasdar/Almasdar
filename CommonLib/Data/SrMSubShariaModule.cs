using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class SrMSubShariaModule
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? ArabicTitle { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public int? ShariaModuleId { get; set; }

        public virtual SrMShariaModule? ShariaModule { get; set; }
    }
}
