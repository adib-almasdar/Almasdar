using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class LoMSalesDepartment
    {
        public LoMSalesDepartment()
        {
            LoMAgents = new HashSet<LoMAgent>();
            LoMSpocs = new HashSet<LoMSpoc>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<LoMAgent> LoMAgents { get; set; }
        public virtual ICollection<LoMSpoc> LoMSpocs { get; set; }
    }
}
