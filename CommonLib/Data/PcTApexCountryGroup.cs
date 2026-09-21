using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Data
{
    public partial class PcTApexCountryGroup
    {
        public int Groupid { get; set; }
        public string Groupname { get; set; } = null!;
        public int CountryId { get; set; }
    }
}
