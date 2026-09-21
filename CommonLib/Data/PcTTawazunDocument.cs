using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTTawazunDocument
    {
        public int Id { get; set; }
        public int? TawazunId { get; set; }
        public string? FileName { get; set; }
        public string? DocumentUri { get; set; }
        public int? VarientId { get; set; }
        public string? DocumentSize { get; set; }
        public string? FilePath { get; set; }
        public string? UploadedBy { get; set; }
        public DateTime? UploadedDate { get; set; }

        public virtual PcTTawazun? Tawazun { get; set; }
    }
}
