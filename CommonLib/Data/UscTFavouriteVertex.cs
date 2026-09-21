using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class UscTFavouriteVertex
    {
        public int Id { get; set; }
        public int VertexId { get; set; }
        public string? UserEmail { get; set; }
        public DateTime? FavouriteDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual UscTVertex Vertex { get; set; } = null!;
    }
}
