using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class HdTAnnouncement
    {
        public int Id { get; set; }
        public string? Announcement { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsDeleted { get; set; }
        public string? ModifiedBy { get; set; }
        public string? FileName { get; set; }
        public string? Url { get; set; }
        public string? Description { get; set; }
    }
}
