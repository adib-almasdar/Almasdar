using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class SkrMResearchType
    {
        public SkrMResearchType()
        {
            SkrTResearchBooks = new HashSet<SkrTResearchBook>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }

        public virtual ICollection<SkrTResearchBook> SkrTResearchBooks { get; set; }
    }
}
