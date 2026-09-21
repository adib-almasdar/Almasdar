using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class ErrorLog
    {
        public int Id { get; set; }
        public string? Apiurl { get; set; }
        public string? Path { get; set; }
        public string? Host { get; set; }
        public string? StackTrace { get; set; }
        public string? RequestBody { get; set; }
        public string? MethodType { get; set; }
        public string? Source { get; set; }
        public string? ExceptionMessage { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? InnerException { get; set; }
    }
}
