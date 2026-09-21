using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class UserAuditLog
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual User? User { get; set; }
    }
}
