using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcMType
    {
        public PcMType()
        {
            PcTApexHistories = new HashSet<PcTApexHistory>();
            PcTApices = new HashSet<PcTApex>();
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

        public virtual ICollection<PcTApexHistory> PcTApexHistories { get; set; }
        public virtual ICollection<PcTApex> PcTApices { get; set; }
        public virtual ICollection<PcTRequestExtendedField> PcTRequestExtendedFields { get; set; }
    }
}
