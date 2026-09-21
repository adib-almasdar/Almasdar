using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTApexTransaction
    {
        public PcTApexTransaction()
        {
            PcTApexStatusTransactionAttachments = new HashSet<PcTApexStatusTransactionAttachment>();
        }

        public int Id { get; set; }
        public int? ApexId { get; set; }
        public string? Action { get; set; }
        public DateTime? Date { get; set; }
        public string? CreatedBy { get; set; }
        public string? Comment { get; set; }
        public string? Status { get; set; }

        public string? FromPersonId { get; set; }
        public string? ToPersonId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string? TransactionBy { get; set; }
        public string? TransactionByDisplayName { get; set; }
        public string? TransactionByRole { get; set; }


        public virtual ICollection<PcTApexStatusTransactionAttachment> PcTApexStatusTransactionAttachments { get; set; }
    }
}
