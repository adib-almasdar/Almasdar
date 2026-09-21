using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class UscMStatus
    {
        public int Id { get; set; }
        public string? StatusName { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? RoleBy { get; set; }
    }
}
