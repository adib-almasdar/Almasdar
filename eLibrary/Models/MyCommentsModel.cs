namespace eLibrary.Models
{
    public class MyCommentsModel
    {
        public int? ReferMessageId { get; set; }
        public int? BookId { get; set; }
        public string? Message { get; set; }
        public int? PageNumber { get; set; }
        public string? Highlight { get; set; }
     
        public string? CommentBy { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CommentDate { get; set; }


    }
}
