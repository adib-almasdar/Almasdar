using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTApexAlUsoolDocument
    {
        public int Id { get; set; }
        public int? ApexId { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentName { get; set; }
        public string? SearchBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ObjectId { get; set; }
        public bool? IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? Status { get; set; }
    }
}
