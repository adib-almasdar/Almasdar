using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTTawazunVarientApex
    {
        public int Id { get; set; }
        public int? TawazunId { get; set; }
        public int? ApexId { get; set; }
        public int? TransactionId { get; set; }
        public int? VarientId { get; set; }

        public virtual PcTApex? Apex { get; set; }
        public virtual PcTTawazun? Tawazun { get; set; }
        public virtual PcTTawazunTransaction? Transaction { get; set; }
    }
}
