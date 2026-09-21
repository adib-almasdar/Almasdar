using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTRequestApex
    {
        public int Id { get; set; }
        public int? RequestId { get; set; }
        public int? ApexId { get; set; }

        public virtual PcTApex? Apex { get; set; }
        public virtual HdTRequest? Request { get; set; }
    }
}
