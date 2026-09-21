using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class HdMStatus
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public string? ModifiedBy { get; set; }
        public string? RoleBy { get; set; }
        public string? ValuePair { get; set; }
        public bool? IsActive { get; set; }
        public int? OrderNumber { get; set; }
    }
}
