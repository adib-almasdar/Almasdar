using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class EmailNotificationsMaster
    {
        public int Id { get; set; }
        public string? Module { get; set; }
        public string? SubModule { get; set; } = null!;
        public string? Subject { get; set; }
        public string? BodyEnglish { get; set; }
        public string? BodyArabic { get; set; }
        public string? Recipient { get; set; }
        public string? Description { get; set; }
    }
}
