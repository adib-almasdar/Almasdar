using Newtonsoft.Json;

namespace eLibrary.Models
{
    public class BookSearchModel
    {
        public string odatacontext { get; set; }
		public string? Message { get; set; }

		[JsonProperty("@odata.count")]
        public int odatacount { get; set; }
        public List<Value> value { get; set; }
    }

    public class SearchHighlights
    {
        public string[] content { get; set; }
        public string[] merged_content { get; set; }

    }

    public class Value
    {
        public float? searchscore { get; set; }

        //[JsonProperty("@search.highlights")]
        // SearchHighlights searchhighlights { get; set; }
        [JsonProperty("@search.highlights")]
        public Dictionary<string, string[]> searchhighlights { get; set; }

        public List<string> MatchSources { get; set; } = new();
        public string? content { get; set; }
        public string? id { get; set; }

        public string? metadata_storage_name { get; set; }
        public string? metadata_storage_path { get; set; }
        public string? UpdatedDate { get; set; }
        public string? Year { get; set; }
        public string? Language { get; set; }
        public string? Category { get; set; }
        public string? SubCategory { get; set; }
        public string? BookType { get; set; }
        public string? VolumeNumber { get; set; }
        public string? BookTitleEnglish { get; set; }
        public string? Author { get; set; }
        public string? Publication { get; set; }
        public string? BookTitleArabic { get; set; }
        public string? translated_text_english { get; set; }
        public string? Country { get; set; }
        public string? UniqueFolderName { get; set; }
        public string? translated_text_arabic { get; set; }
        public string merged_content { get; set; }
        public string? Version { get; set; }
        public string? VisibilityOfBook { get; set; }
        public string? Description { get; set; }
        public string? UploadedBy { get; set; }
        public string? ApproverName { get; set; }
        public string? ApproverDateTime { get; set; }
        public string? ArabicKeywords { get; set; }
        public string? EnglishKeywords { get; set; }
        public bool? IsDeleted { get; set; }
        public string? BookUrl { get; set; }
        public string? ThumbnailUrl { get; set; }
        public int? BookID { get; set; }

    }

}


