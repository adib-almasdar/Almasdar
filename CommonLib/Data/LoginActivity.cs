using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class LoginActivity
    {
        public int Id { get; set; }
        public string? EmailId { get; set; }
        public DateTime? LoginDateTime { get; set; }
        public string? ApplicationName { get; set; }
    }
}
