using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class Rolehistory
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Role? Role { get; set; }
        public virtual User? User { get; set; }
    }
}
