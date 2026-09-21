using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTRequestAlUsoolDocumentsLink
    {
        public int Id { get; set; }
        public int? RequestId { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentName { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? SearchBy { get; set; }
        public string? ObjectId { get; set; }

        public virtual HdTRequest? Request { get; set; }
    }
}
