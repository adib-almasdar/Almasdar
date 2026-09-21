using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class UserRoleMapping
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }

        public virtual Role? Role { get; set; }
        public virtual User? User { get; set; }
    }
}
