using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class LoMAgent
    {
        public int Id { get; set; }
        public string? EmailId { get; set; }
        public bool? Status { get; set; }
        public int? SalesDepartment { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual LoMSalesDepartment? SalesDepartmentNavigation { get; set; }
    }
}
