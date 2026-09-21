using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class HdTRequestDelegation
    {
        public int Id { get; set; }
        public int? RequestId { get; set; }
        public string? DelegatedTo { get; set; }
        public string? DelegatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
