namespace eLibrary.Models
{
    public class BookModelforMetadata
    {
        public int? BookID { get; set; }
        public string? Category { get; set; }
        public string? SubCategory { get; set; }
        public string? BookType { get; set; }
        public string? BookTitleArabic { get; set; }
        public string? BookTitleEnglish { get; set; }
        public string? Author { get; set; }
        public int? VolumeNumber { get; set; }
        public string? Publication { get; set; }
        public int? Version { get; set; }
        public string? Country { get; set; }
        public string? Language { get; set; }
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
    }
}
