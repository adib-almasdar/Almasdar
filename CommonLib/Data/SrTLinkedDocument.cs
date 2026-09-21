using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class SrTLinkedDocument
    {
        public int DocumentId { get; set; }
        public int? ReferDocumentId { get; set; }
        public int Id { get; set; }

        public virtual SrTShariaDocument? ReferDocument { get; set; }
    }
}
