using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTPackageVarientTawazun
    {
        public int Id { get; set; }
        public string? ParentVarientTawazunName { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? PackageTawazunId { get; set; }
        public int? ProductVarientTawaunId { get; set; }

        public virtual PcTTawazun? PackageTawazun { get; set; }
        public virtual PcTTawazunVarient? ProductVarientTawaun { get; set; }
    }
}
