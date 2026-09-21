using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcMSubjectOrInstrument
    {
        public PcMSubjectOrInstrument()
        {
            HdTRequestHistories = new HashSet<HdTRequestHistory>();
            PcTRequestExtendedFields = new HashSet<PcTRequestExtendedField>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public bool? Status { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? OrderNumber { get; set; }

        public virtual ICollection<HdTRequestHistory> HdTRequestHistories { get; set; }
        public virtual ICollection<PcTRequestExtendedField> PcTRequestExtendedFields { get; set; }
    }
}
