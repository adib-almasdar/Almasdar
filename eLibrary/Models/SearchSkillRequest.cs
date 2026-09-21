using Newtonsoft.Json;

namespace eLibrary.Models
{
    public class SearchSkillRequest
    {
        [JsonProperty("values")]
        public List<SearchSkillRequestRecord> Values { get; set; } = new();
    }
    public class SearchSkillRequestRecord
    {
        [JsonProperty("recordId")]
        public string RecordId { get; set; }

        [JsonProperty("data")]
        public SearchSkillRequestData Data { get; set; } = new();
    }
    public class SearchSkillRequestData
    {
        [JsonProperty("Category")]
        public string? Category { get; set; }
    }
    public class SearchSkillResponse
    {
        [JsonProperty("values")]
        public List<SearchSkillResponseRecord> Values { get; set; } = new();
    }
    public class SearchSkillResponseRecord
    {
        [JsonProperty("recordId")]
        public string RecordId { get; set; }

        [JsonProperty("Data")]
        public SearchSkillResponseData Data { get; set; } = new();
    }
    public class SearchSkillResponseData
    {
        [JsonProperty("CategoryDecoded")]
        public List<string> CategoryDecoded { get; set; } = new();
    }

}
