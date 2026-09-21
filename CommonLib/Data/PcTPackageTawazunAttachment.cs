using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTPackageTawazunAttachment
    {
        public int Id { get; set; }
        public string? AttachmentUrl { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileSize { get; set; }
        public string? TransactionBy { get; set; }
        public DateTime? TransactionDate { get; set; }
        public int? PackageTawazunId { get; set; }

        public virtual PcTTawazun? PackageTawazun { get; set; }
    }
}
