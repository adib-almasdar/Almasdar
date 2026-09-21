using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTPackageParentTawazun
    {
        public int Id { get; set; }
        public string? ParentTawazunName { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? PackageTawazunId { get; set; }
        public int? ParentTawaunId { get; set; }

        public virtual PcTTawazun? PackageTawazun { get; set; }
        public virtual PcTTawazun? ParentTawaun { get; set; }
    }
}
