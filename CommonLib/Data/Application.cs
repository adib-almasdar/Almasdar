using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class Application
    {
        public Application()
        {
            AccessDeniedLogs = new HashSet<AccessDeniedLog>();
            Roles = new HashSet<Role>();
        }

        public int ApplicationId { get; set; }
        public string? ApplicationName { get; set; }

        public virtual ICollection<AccessDeniedLog> AccessDeniedLogs { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
