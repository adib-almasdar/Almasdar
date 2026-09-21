using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class HdTRequestMyTeam
    {
        public int Id { get; set; }
        public int? RequestId { get; set; }
        public string? EmailId { get; set; }
        public string? CreatedBy { get; set; }

        public virtual HdTRequest? Request { get; set; }
    }
}
