using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class UscTProductCart
    {
        public int Id { get; set; }
        public int? VertexId { get; set; }
        public string? UserId { get; set; }
        public DateTime? AddDate { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? RemoveDate { get; set; }

        public virtual UscTVertex? Vertex { get; set; }
    }
}
