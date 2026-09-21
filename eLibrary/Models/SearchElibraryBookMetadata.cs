namespace eLibrary.Models
{
    public class SearchElibraryBookMetadata
    {
        public string? Query { get; set; }
        public string? Filter { get; set; }
        public int Top { get; set; }
        public int Skip { get; set; }
        public bool? IsGeneralView { get; set; } = false;
    }
}
