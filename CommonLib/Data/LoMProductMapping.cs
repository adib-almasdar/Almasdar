using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class LoMProductMapping
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string? Product { get; set; }
        public int? ProductType { get; set; }
        public string? Description { get; set; }

        public virtual LoMProductType? ProductTypeNavigation { get; set; }
    }
}
