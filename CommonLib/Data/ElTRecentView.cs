using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class ElTRecentView
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public string? UserEmail { get; set; }
        public int? PageNumber { get; set; }
        public DateTime? ViewDate { get; set; }

        public virtual ElTBook? Book { get; set; }
    }
}
