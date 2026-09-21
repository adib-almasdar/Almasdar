using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class HdTRequest
    {
        public HdTRequest()
        {
            HdTRequestHistories = new HashSet<HdTRequestHistory>();
            HdTRequestMyTeams = new HashSet<HdTRequestMyTeam>();
            HdTRequestQuestionAnswers = new HashSet<HdTRequestQuestionAnswer>();
            HdTRequestVertexQuestionAnswers = new HashSet<HdTRequestVertexQuestionAnswer>();
            HdTRequestsPeers = new HashSet<HdTRequestsPeer>();
            HdTRequestsStatusTransactions = new HashSet<HdTRequestsStatusTransaction>();
            HdTStatusTransactionAttachments = new HashSet<HdTStatusTransactionAttachment>();
            PcTApexRequests = new HashSet<PcTApexRequest>();
            PcTRequestAlUsoolDocumentsLinks = new HashSet<PcTRequestAlUsoolDocumentsLink>();
            PcTRequestApices = new HashSet<PcTRequestApex>();
            PcTRequestExtendedFields = new HashSet<PcTRequestExtendedField>();
            PcTRequestVarients = new HashSet<PcTRequestVarient>();
        }

        public int RequestId { get; set; }
        public int? RequestType { get; set; }
        public int? Branch { get; set; }
        public int? Department { get; set; }
        public string? RequesterName { get; set; }
        public string? RequesterId { get; set; }
        public string? CurrentRequestOwner { get; set; }
        public string? Title { get; set; }
        public string? Phone { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhoneNumber { get; set; }
        public string? CustomerRimnumber { get; set; }
        public string? FinanceNumber { get; set; }
        public int? Category { get; set; }
        public int? Product { get; set; }
        public int? SubProduct { get; set; }
        public string? Notes { get; set; }
        public string? History { get; set; }
        public int? Area { get; set; }
        public string? ShariaExpert { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CustomRequestId { get; set; }
        public string? BranchName { get; set; }
        public string? DepartmentName { get; set; }
        public string? NotesWithoutHtml { get; set; }
        public int? OriginalCategory { get; set; }
        public int? OriginalProduct { get; set; }
        public int? OriginalSubProduct { get; set; }
        public bool? IsMaterData { get; set; }
        public string? HelpdeskManager { get; set; }

        public string? OnBehalfOfEmail { get; set; }
        public string? OnBehalfOfBranch { get; set; }
        public string? OnBehalfOfDepartment { get; set; }
        public string? OnBehalfOfPhone { get; set; }
        public string? ShariaStructure { get; set; }

        public string? AdibsRole { get; set; }
        public string? ScoreCard { get; set; }
        public string? AdibfeesCurrency { get; set; }
        public string? Adibfees { get; set; }
        public string? Remarks { get; set; }
        public string? Suk_ADIBParticipatedQuestion { get; set; }
        public string? Suk_ADIBParticipatedIssuanceQuestion { get; set; }
        public string? Suk_ADIBReviewedSukukQuestion { get; set; }
        public string? Suk_AreWeAllowedQuestion { get; set; }
        public string? Suk_DocumentBasedOnQuestion { get; set; }
        public string? Suk_FatwaRequiredQuestion { get; set; }
        public string? Suk_IssueAmountCurrency { get; set; }
        public string? Suk_IssueAmount { get; set; }
        public string? Suk_ObligorType { get; set; }
        public string? Suk_OtherIslamicBanks { get; set; }
        public string? Suk_ProgramSizeCurrency { get; set; }
        public string? Suk_ProgramSize { get; set; }
        public string? Suk_TypeOfOffering { get; set; }
        public string? Suk_TypeOfProgram { get; set; }
        public string? Suk_TypeOfSukuk { get; set; }
        public string? Suk_Obligor { get; set; }
        public string? Suk_TransactionTimeline { get; set; }
        public string? Suk_LaunchDate { get; set; }
        public string? Suk_SukukHoldersLegalCounsel { get; set; }
        public string? Suk_ObligorsLegalCounsel { get; set; }
        public string? Synd_ADIBReviewedQuestion { get; set; }
        public string? Synd_ADIBParticipationCurrency { get; set; }
        public string? Synd_ADIBParticipation { get; set; }
        public string? Synd_ADIBsRole { get; set; }
        public string? Synd_AreWeAllowedQuestion { get; set; }
        public string? Synd_ClientsType { get; set; }
        public string? Synd_DealType { get; set; }
        public string? Synd_DocumentBasedOnQuestion { get; set; }
        public string? Synd_OtherIslamicBanks { get; set; }
        public string? Synd_TransactionAmountCurrency { get; set; }
        public string? Synd_TransactionAmount { get; set; }
        public string? Synd_TransactionType { get; set; }
        public string? Synd_ClientsName { get; set; }
        public string? Synd_TransactionTimeline { get; set; }
        public string? Synd_SyndicateLegalCounsel { get; set; }
        public string? Synd_ObligorsLegalCounsel { get; set; }

        public bool? IsPeerRequestHidden { get; set; }
        public bool? IsDelegatedRequest { get; set; }
        public bool? IsRequestCreatedBy_HDM { get; set; }


        public virtual HdMArea? AreaNavigation { get; set; }
        public virtual HdMBranch? BranchNavigation { get; set; }
        public virtual HdMCategory? CategoryNavigation { get; set; }
        public virtual HdMDepartment? DepartmentNavigation { get; set; }
        public virtual PcMSegment? OriginalCategoryNavigation { get; set; }
        public virtual PcMCategory? OriginalProductNavigation { get; set; }
        public virtual UscTVertex? OriginalSubProductNavigation { get; set; }
        public virtual HdMProduct? ProductNavigation { get; set; }
        public virtual HdMRequestType? RequestTypeNavigation { get; set; }
        public virtual HdMSubProduct? SubProductNavigation { get; set; }
        public virtual ICollection<HdTRequestHistory> HdTRequestHistories { get; set; }
        public virtual ICollection<HdTRequestMyTeam> HdTRequestMyTeams { get; set; }
        public virtual ICollection<HdTRequestQuestionAnswer> HdTRequestQuestionAnswers { get; set; }
        public virtual ICollection<HdTRequestVertexQuestionAnswer> HdTRequestVertexQuestionAnswers { get; set; }
        public virtual ICollection<HdTRequestsPeer> HdTRequestsPeers { get; set; }
        public virtual ICollection<HdTRequestsStatusTransaction> HdTRequestsStatusTransactions { get; set; }
        public virtual ICollection<HdTStatusTransactionAttachment> HdTStatusTransactionAttachments { get; set; }
        public virtual ICollection<PcTApexRequest> PcTApexRequests { get; set; }
        public virtual ICollection<PcTRequestAlUsoolDocumentsLink> PcTRequestAlUsoolDocumentsLinks { get; set; }
        public virtual ICollection<PcTRequestApex> PcTRequestApices { get; set; }
        public virtual ICollection<PcTRequestExtendedField> PcTRequestExtendedFields { get; set; }
        public virtual ICollection<PcTRequestVarient> PcTRequestVarients { get; set; }
    }
}
