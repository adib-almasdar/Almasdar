using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class LoMPointsConfiguration
    {
        public int Id { get; set; }
        public string? Product { get; set; }
        public string? Stage { get; set; }
        public string? Points { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Segment { get; set; }
        public int? Country { get; set; }
        public int? SubSegment { get; set; }
        public int? ProductType { get; set; }
    }
}
