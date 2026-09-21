using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTApexSupportingDocument
    {
        public int Id { get; set; }
        public int? ShariaRepoId { get; set; }
        public int? ApexId { get; set; }
        public int? DocumentType { get; set; }

        public virtual PcTApex? Apex { get; set; }
        public virtual SrMDocumentType? DocumentTypeNavigation { get; set; }
        public virtual SrTShariaDocument? ShariaRepo { get; set; }
    }
}
