using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class Role
    {
        public Role()
        {
            Rolehistories = new HashSet<Rolehistory>();
            UserRoleMappings = new HashSet<UserRoleMapping>();
        }

        public int RoleId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public int? ApplicationId { get; set; }
        public string? Activity { get; set; }

        public virtual Application? Application { get; set; }
        public virtual ICollection<Rolehistory> Rolehistories { get; set; }
        public virtual ICollection<UserRoleMapping> UserRoleMappings { get; set; }
    }
}
