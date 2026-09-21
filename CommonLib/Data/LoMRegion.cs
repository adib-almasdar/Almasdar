using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class LoMRegion
    {
        public LoMRegion()
        {
            LoTLeads = new HashSet<LoTLead>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public bool? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Country { get; set; }

        public virtual LoMCountry? CountryNavigation { get; set; }
        public virtual ICollection<LoTLead> LoTLeads { get; set; }
    }
}
