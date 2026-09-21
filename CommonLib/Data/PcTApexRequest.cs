using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTApexRequest
    {
        public int Id { get; set; }
        public int? ApexId { get; set; }
        public int? RequestId { get; set; }
        public bool? IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? Status { get; set; }

        public string? RequestName { get; set; }

        public string? RequestStatus { get; set; }

        public virtual HdTRequest? Request { get; set; }
    }
}
