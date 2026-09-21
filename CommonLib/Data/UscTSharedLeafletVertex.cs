using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class UscTSharedLeafletVertex
    {
        public int Id { get; set; }
        public int? VertexId { get; set; }
        public string? ToEmail { get; set; }
        public string? ToName { get; set; }
        public bool? IsMailSent { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }

        public virtual UscTVertex? Vertex { get; set; }
    }
}
