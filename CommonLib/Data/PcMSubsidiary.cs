using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcMSubsidiary
    {
        public PcMSubsidiary()
        {
            HdTRequestHistories = new HashSet<HdTRequestHistory>();
            PcTTawazuns = new HashSet<PcTTawazun>();
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
        public int? OrganisationId { get; set; }
        public int? OrderNumber { get; set; }

        public virtual PcMOrganisation? Organisation { get; set; }
        public virtual ICollection<HdTRequestHistory> HdTRequestHistories { get; set; }
        public virtual ICollection<PcTTawazun> PcTTawazuns { get; set; }
    }
}
