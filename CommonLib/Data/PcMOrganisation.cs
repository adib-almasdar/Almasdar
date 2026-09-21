using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcMOrganisation
    {
        public PcMOrganisation()
        {
            HdTRequestHistories = new HashSet<HdTRequestHistory>();
            PcMSubsidiaries = new HashSet<PcMSubsidiary>();
            PcTRequestExtendedFields = new HashSet<PcTRequestExtendedField>();
            UscTVertices = new HashSet<UscTVertex>();
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
        public string? CountryCode { get; set; }
        public int? OrderNumber { get; set; }

        public virtual ICollection<HdTRequestHistory> HdTRequestHistories { get; set; }
        public virtual ICollection<PcMSubsidiary> PcMSubsidiaries { get; set; }
        public virtual ICollection<PcTRequestExtendedField> PcTRequestExtendedFields { get; set; }
        public virtual ICollection<UscTVertex> UscTVertices { get; set; }
    }
}
