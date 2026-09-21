using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class HdTRequestsFieldHistory
    {
        public int Id { get; set; }
        public int? RequestId { get; set; }
        public string? FieldName { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
