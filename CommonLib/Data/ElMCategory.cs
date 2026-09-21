using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class ElMCategory
    {
        public ElMCategory()
        {
            ElMSubCategories = new HashSet<ElMSubCategory>();
            ElTBooks = new HashSet<ElTBook>();
            ElTBooksHistories = new HashSet<ElTBooksHistory>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ThumbnailUrl { get; set; }
        public bool? IsDeleted { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? ArabicTitle { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; set; }

        public virtual ICollection<ElMSubCategory> ElMSubCategories { get; set; }
        public virtual ICollection<ElTBook> ElTBooks { get; set; }
        public virtual ICollection<ElTBooksHistory> ElTBooksHistories { get; set; }
    }
}
