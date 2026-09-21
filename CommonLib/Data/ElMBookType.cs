using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class ElMBookType
    {
        public ElMBookType()
        {
            ElTBooks = new HashSet<ElTBook>();
            ElTBooksHistories = new HashSet<ElTBooksHistory>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public virtual ICollection<ElTBook> ElTBooks { get; set; }
        public virtual ICollection<ElTBooksHistory> ElTBooksHistories { get; set; }
    }
}
