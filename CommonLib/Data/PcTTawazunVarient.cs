using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTTawazunVarient
    {
        public PcTTawazunVarient()
        {
            PcTTawazunPackageVarients = new HashSet<PcTTawazunPackageVarient>();
            PcTTawazunVarientHistories = new HashSet<PcTTawazunVarientHistory>();
            UscTVertices = new HashSet<UscTVertex>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? TawazunFkid { get; set; }
        public string? FatwaLinks { get; set; }
        public string? Description { get; set; }
        public string? TawazunId { get; set; }
        public string? VarientId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? Segment { get; set; }
        public int? SubSegment { get; set; }
        public string? CustomVarientId { get; set; }
        public bool? Active { get; set; }
        public bool? IsDeleted { get; set; }
        public string? DisableBy { get; set; }
        public DateTime? DisableDate { get; set; }
        public int? OldTawazunVarientId { get; set; }
        public int? VarientRootId { get; set; }
        public bool? Acknowledgement { get; set; }
        public bool? ComplyStatus { get; set; }
        public DateTime? CompliedDate { get; set; }
        public string? CompliedBy { get; set; }
        public string? ComplyComments { get; set; }

        public virtual PcMSegment? SegmentNavigation { get; set; }
        public virtual PcMCategory? SubSegmentNavigation { get; set; }
        public virtual PcTTawazun? TawazunFk { get; set; }
        public virtual ICollection<PcTTawazunPackageVarient> PcTTawazunPackageVarients { get; set; }
        public virtual ICollection<PcTTawazunVarientHistory> PcTTawazunVarientHistories { get; set; }
        public virtual ICollection<UscTVertex> UscTVertices { get; set; }
    }
}
