using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class LoTEmployeePoint
    {
        public int Id { get; set; }
        public string? EmailId { get; set; }
        public string? Points { get; set; }
        public string? AllTimePoints { get; set; }
        public string? RedeemedPoints { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
