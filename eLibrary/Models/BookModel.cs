namespace eLibrary.Models
{
    public class BookModel
    {
        public int? BookID { get; set; }
        public int? Category { get; set; }
        public int? SubCategory { get; set; }
        public int? BookType { get; set; }
        public string? BookTitleArabic { get; set; }
        public string? BookTitleEnglish { get; set; }
        public string? Author { get; set; }
        public string? VolumeNumber { get; set; }
        public string? Publication { get; set; }
        public string? Version { get; set; }
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
        public string? UniqueFolderName { get; set; }
        public string? LinkedBooksId { get; set; }
        public string? UnLinkedBooksId { get; set; }
        public bool? IsDownloadable { get; set; }
        public bool? IsPrintable { get; set; }
        public IFormFile? bookfile { get; set; }
        public IFormFile? thumbnailfile { get; set; }
        public IFormFile? approverattachmentfile { get; set; }
    }
}
