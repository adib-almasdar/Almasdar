using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Data
{
    public partial class HdTRequestNonAssigneeActivity
    {
        public int Id { get; set; }
        public int? RequestId { get; set; }
        public string? Role { get; set; }
        public string? CurrentAssignee { get; set; }
        public string? ActingUser { get; set; }
        public string? PreviousStatus { get; set; }
        public string? ActionPerformedStatus { get; set; }
        public DateTime? ActionTakenDate { get; set; }
    }
}
