using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class ElTFavouriteBook
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public string? UserEmail { get; set; }
        public DateTime? FavouriteDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ElTBook? Book { get; set; }
    }
}
