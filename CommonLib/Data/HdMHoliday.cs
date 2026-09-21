using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class HdMHoliday
    {
        public int HolidayId { get; set; }
        public string? Desciption { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
