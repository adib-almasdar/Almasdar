using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class ReportsTable
    {
        public int SNo { get; set; }
        public string? SchemaName { get; set; }
        public string? TableName { get; set; }
        public bool? Isactive { get; set; }
    }
}
