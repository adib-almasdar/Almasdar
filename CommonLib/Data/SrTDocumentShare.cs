using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class SrTDocumentShare
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string? SharedBy { get; set; }
        public string? SharedTo { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime? SharedOn { get; set; }
        public string? AccessLevel { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
