using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class HdMShariaStaff
    {
        public int Id { get; set; }
        public string? Staff { get; set; }
        public string? BackupStaff { get; set; }
        public bool? Status { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
