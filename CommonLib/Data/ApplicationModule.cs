using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class ApplicationModule
    {
        public int Id { get; set; }
        public string? ApplicationName { get; set; }
        public string? AplicationUrl { get; set; }
        public string? ApplicableRoles { get; set; }
        public bool? IsActive { get; set; }
    }
}
