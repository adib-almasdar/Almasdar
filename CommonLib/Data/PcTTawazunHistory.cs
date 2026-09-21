using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTTawazunHistory
    {
        public int Id { get; set; }
        public int? TawazunId { get; set; }
        public int? ProductConceptId { get; set; }
        public int? ProductCreationId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Comment { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? Status { get; set; }
        public string? ProductVarient { get; set; }
        public int? Country { get; set; }
        public int? BusinessUnit { get; set; }
        public int? Division { get; set; }
        public int? Type { get; set; }
        public int? Subject { get; set; }
        public string? OthersTawazunIds { get; set; }
        public string? Approver { get; set; }
        public string? CustomTawazunId { get; set; }
        public int? SubSidiary { get; set; }
        public int? TawazunType { get; set; }
        public bool? Active { get; set; }
        public bool? IsDeleted { get; set; }
        public int? Purpose { get; set; }
        public bool? IsModifiedTawazun { get; set; }
        public string? PackageParentTawazun { get; set; }
        public string? PackageParentVarientTawazun { get; set; }
        public int? Segment { get; set; }
        public int? Subsegment { get; set; }

        public int? TawazunCountryGroups { get; set; }

        public virtual PcTTawazun? Tawazun { get; set; }
    }
}
