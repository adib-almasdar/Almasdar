using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class ElTBook
    {
        public ElTBook()
        {
            ElTBookMarkComments = new HashSet<ElTBookMarkComment>();
            ElTBooksHistories = new HashSet<ElTBooksHistory>();
            ElTFavouriteBooks = new HashSet<ElTFavouriteBook>();
            ElTLinkedBooks = new HashSet<ElTLinkedBook>();
            ElTRecentViews = new HashSet<ElTRecentView>();
        }

        public int BookId { get; set; }
        public int? Category { get; set; }
        public int? SubCategory { get; set; }
        public int? BookType { get; set; }
        public string? BookTitleArabic { get; set; }
        public string? BookTitleEnglish { get; set; }
        public string? Author { get; set; }
        public string? Publication { get; set; }
        public int? Country { get; set; }
        public int? Language { get; set; }
        public int? Year { get; set; }
        public string? VisibilityOfBook { get; set; }
        public string? Description { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UploadedBy { get; set; }
        public string? ApproverName { get; set; }
        public DateTime? ApproverDateTime { get; set; }
        public string? ApprovalAttachmentsUrl { get; set; }
        public string? ArabicKeywords { get; set; }
        public string? EnglishKeywords { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? BookUrl { get; set; }
        public bool? IsDeleted { get; set; }
        public string? Version { get; set; }
        public string? VolumeNumber { get; set; }
        public string? UniqueFolderName { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; set; }
        public string? DeletingReason { get; set; }
        public string? DeletionApprovalFile { get; set; }
        public bool? IsDownloadable { get; set; }
        public bool? IsPrintable { get; set; }

        public virtual ElMBookType? BookTypeNavigation { get; set; }
        public virtual ElMCategory? CategoryNavigation { get; set; }
        public virtual ElMCountry? CountryNavigation { get; set; }
        public virtual ElMLanguage? LanguageNavigation { get; set; }
        public virtual ElMSubCategory? SubCategoryNavigation { get; set; }
        public virtual ICollection<ElTBookMarkComment> ElTBookMarkComments { get; set; }
        public virtual ICollection<ElTBooksHistory> ElTBooksHistories { get; set; }
        public virtual ICollection<ElTFavouriteBook> ElTFavouriteBooks { get; set; }
        public virtual ICollection<ElTLinkedBook> ElTLinkedBooks { get; set; }
        public virtual ICollection<ElTRecentView> ElTRecentViews { get; set; }
    }
}
