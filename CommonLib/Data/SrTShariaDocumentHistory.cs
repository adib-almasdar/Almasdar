using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class SrTShariaDocumentHistory
    {
        public int HistoryId { get; set; }
        public int DocumentId { get; set; }
        public int? DocumentTypeId { get; set; }
        public string? ShariaModuleId { get; set; }
        public string? SubShariaModuleId { get; set; }
        public string? TitleArabic { get; set; }
        public string? TitleEnglish { get; set; }
        public int? Regulatory { get; set; }
        public int? NumberOfPages { get; set; }
        public int? Country { get; set; }
        public int? Language { get; set; }
        public int? Year { get; set; }
        public string? ArabicKeywords { get; set; }
        public string? EnglishKeywords { get; set; }
        public string? Description { get; set; }
        public string? FileUrl { get; set; }
        public string? ThumbnailUrl { get; set; }
        public DateTime? UploadedDate { get; set; }
        public string? UploadedBy { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public string? ApprovalAttachmentsUrl { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public int? Product { get; set; }
        public string? UnderlyingContracts { get; set; }
        public string? Departments { get; set; }
        public DateTime? DateofIssuanceoftheShariaResolution { get; set; }
        public string? ResolutionNo { get; set; }
        public string? SerialNumber { get; set; }
        public string? YearlySerialNumber { get; set; }
        public bool? IsDownloadable { get; set; }
        public bool? IsPrintable { get; set; }
        public DateTime? DateOfNotificationOfResolution { get; set; }
        public string? GroupInstitutions { get; set; }
        public string? ShariaModuleValues { get; set; }
        public string? SubShariaModuleValues { get; set; }
        public string? RecipientTo { get; set; }
        public string? RecipientCC { get; set; }

        public virtual SrMCountry? CountryNavigation { get; set; }
        public virtual SrTShariaDocument Document { get; set; } = null!;
        public virtual SrMDocumentType? DocumentType { get; set; }
        public virtual SrMLanguage? LanguageNavigation { get; set; }
        public virtual SrMRegulatory? RegulatoryNavigation { get; set; }
    }
}
