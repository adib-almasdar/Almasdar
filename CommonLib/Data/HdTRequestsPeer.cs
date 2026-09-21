using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class HdTRequestsPeer
    {
        public int Id { get; set; }
        public int? RequestId { get; set; }
        public string? PeersEmailId { get; set; }
        public string? Status { get; set; }
        public DateTime? AddedDate { get; set; }
        public string? AddedBy { get; set; }

        public virtual HdTRequest? Request { get; set; }
    }
}
