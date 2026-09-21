using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class ElTLinkedBook
    {
        public int BookId { get; set; }
        public int? ReferBookId { get; set; }
        public int Id { get; set; }

        public virtual ElTBook? ReferBook { get; set; }
    }
}
