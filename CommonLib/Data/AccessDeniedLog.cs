using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class AccessDeniedLog
    {
        public int Id { get; set; }
        public int? ApplicationId { get; set; }
        public int? UserId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Application? Application { get; set; }
        public virtual User? User { get; set; }
    }
}
