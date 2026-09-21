using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcMStatus
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool? IsDeleted { get; set; }
        public string? RoleBy { get; set; }
        public string? ValuePair { get; set; }
    }
}
