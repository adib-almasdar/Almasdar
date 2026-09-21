using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class UscTVertexApprover
    {
        public int Id { get; set; }
        public string? ApproverEmailId { get; set; }
        public int? VertexId { get; set; }
        public string? Createdby { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual UscTVertex? Vertex { get; set; }
    }
}
