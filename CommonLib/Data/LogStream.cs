using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Data
{
    public partial class LogStream
    {
        public int Id { get; set; }
        public string? Log { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
