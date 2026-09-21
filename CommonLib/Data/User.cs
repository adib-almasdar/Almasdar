using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class User
    {
        public User()
        {
            AccessDeniedLogs = new HashSet<AccessDeniedLog>();
            Rolehistories = new HashSet<Rolehistory>();
            UserRoleMappings = new HashSet<UserRoleMapping>();
        }

        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? EmailId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? Department { get; set; }
        public string? ModifiedBy { get; set; }

        public virtual ICollection<AccessDeniedLog> AccessDeniedLogs { get; set; }
        public virtual ICollection<Rolehistory> Rolehistories { get; set; }
        public virtual ICollection<UserRoleMapping> UserRoleMappings { get; set; }
    }
}
