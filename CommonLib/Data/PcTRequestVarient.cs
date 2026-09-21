using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTRequestVarient
    {
        public int Id { get; set; }
        public string? Varient { get; set; }
        public int? RequestId { get; set; }

        public virtual HdTRequest? Request { get; set; }
    }
}
