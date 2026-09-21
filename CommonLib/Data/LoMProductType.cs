using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class LoMProductType
    {
        public LoMProductType()
        {
            LoMProductMappings = new HashSet<LoMProductMapping>();
        }

        public int Id { get; set; }
        public string? Type { get; set; }

        public virtual ICollection<LoMProductMapping> LoMProductMappings { get; set; }
    }
}
