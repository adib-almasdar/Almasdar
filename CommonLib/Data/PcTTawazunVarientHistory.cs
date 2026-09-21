using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTTawazunVarientHistory
    {
        public int Id { get; set; }
        public int? VarientId { get; set; }
        public int? TawazunId { get; set; }
        public string? FatwaLinks { get; set; }
        public string? Description { get; set; }
        public int? Segment { get; set; }
        public int? SubSegment { get; set; }
        public string? CustomVarientId { get; set; }
        public bool? Active { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? VarientAlUsoolDocuments { get; set; }
        public string? VarientApx { get; set; }
        public string? Name { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? Status { get; set; }
        public string? Comments { get; set; }

        public virtual PcTTawazun? Tawazun { get; set; }
        public virtual PcTTawazunVarient? Varient { get; set; }
    }
}
