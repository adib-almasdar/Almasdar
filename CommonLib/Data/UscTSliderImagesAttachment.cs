using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class UscTSliderImagesAttachment
    {
        public int Id { get; set; }
        public int? VertexId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? FileName { get; set; }
        public string? FileSize { get; set; }
        public string? FilePath { get; set; }

        public virtual UscTVertex? Vertex { get; set; }
    }
}
