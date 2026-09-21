using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class StandardMessageMaster
    {
        public int Id { get; set; }
        public string? ModuleName { get; set; }
        public string? SubModuleName { get; set; }
        public string? StatusCondition { get; set; }
        public string? Message { get; set; }
    }
}
