using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcMTawazunType
    {
        public PcMTawazunType()
        {
            PcTTawazuns = new HashSet<PcTTawazun>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual ICollection<PcTTawazun> PcTTawazuns { get; set; }
    }
}
