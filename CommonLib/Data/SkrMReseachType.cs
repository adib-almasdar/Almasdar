using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class SkrMReseachType
    {
        public SkrMReseachType()
        {
            SkrTResearchBooks = new HashSet<SkrTResearchBook>();
            SkrTResearchTypeLogs = new HashSet<SkrTResearchTypeLog>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<SkrTResearchBook> SkrTResearchBooks { get; set; }
        public virtual ICollection<SkrTResearchTypeLog> SkrTResearchTypeLogs { get; set; }
    }
}
