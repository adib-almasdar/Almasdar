using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTTawazunVarientAlUsoolDocument
    {
        public int Id { get; set; }
        public int? TawazunId { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentName { get; set; }
        public string? SearchBy { get; set; }
        public int? VarientId { get; set; }
        public string? ObjectId { get; set; }

        public virtual PcTTawazun? Tawazun { get; set; }
    }
}
