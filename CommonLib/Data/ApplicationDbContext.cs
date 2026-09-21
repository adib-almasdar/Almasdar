using System;
using System.Collections.Generic;
//using Helpdesk.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CommonLib.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessDeniedLog> AccessDeniedLogs { get; set; } = null!;
        public virtual DbSet<Application> Applications { get; set; } = null!;
        public virtual DbSet<ApplicationModule> ApplicationModules { get; set; } = null!;
        public virtual DbSet<ComMCountry> ComMCountries { get; set; } = null!;
        public virtual DbSet<ComTLanguage> ComTLanguages { get; set; } = null!;
        public virtual DbSet<ElMBookType> ElMBookTypes { get; set; } = null!;
        public virtual DbSet<ElMCategory> ElMCategories { get; set; } = null!;
        public virtual DbSet<ElMCountry> ElMCountries { get; set; } = null!;
        public virtual DbSet<ElMLanguage> ElMLanguages { get; set; } = null!;
        public virtual DbSet<ElMSubCategory> ElMSubCategories { get; set; } = null!;
        public virtual DbSet<ElTBook> ElTBooks { get; set; } = null!;
        public virtual DbSet<ElTBookMarkComment> ElTBookMarkComments { get; set; } = null!;
        public virtual DbSet<ElTBooksHistory> ElTBooksHistories { get; set; } = null!;
        public virtual DbSet<ElTFavouriteBook> ElTFavouriteBooks { get; set; } = null!;
        public virtual DbSet<ElTLinkedBook> ElTLinkedBooks { get; set; } = null!;
        public virtual DbSet<ElTRecentView> ElTRecentViews { get; set; } = null!;
        public virtual DbSet<EmailNotificationsMaster> EmailNotificationsMasters { get; set; } = null!;
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; } = null!;
        public virtual DbSet<HdMArea> HdMAreas { get; set; } = null!;
        public virtual DbSet<HdMBranch> HdMBranches { get; set; } = null!;
        public virtual DbSet<HdMCategory> HdMCategories { get; set; } = null!;
        public virtual DbSet<HdMDepartment> HdMDepartments { get; set; } = null!;
        public virtual DbSet<HdMEmailTemplate> HdMEmailTemplates { get; set; } = null!;
        public virtual DbSet<HdMHoliday> HdMHolidays { get; set; } = null!;
        public virtual DbSet<HdMProduct> HdMProducts { get; set; } = null!;
        public virtual DbSet<HdMQuestion> HdMQuestions { get; set; } = null!;
        public virtual DbSet<HdMRequestType> HdMRequestTypes { get; set; } = null!;
        public virtual DbSet<HdMResearchType> HdMResearchTypes { get; set; } = null!;
        public virtual DbSet<HdMShariaStaff> HdMShariaStaffs { get; set; } = null!;
        public virtual DbSet<HdMStatus> HdMStatuses { get; set; } = null!;
        public virtual DbSet<HdMSubProduct> HdMSubProducts { get; set; } = null!;
        public virtual DbSet<HdMWorkingShift> HdMWorkingShifts { get; set; } = null!;

        public virtual DbSet<HdMSukukAdibparticipatedIssuanceQuestionValue> HdMSukukAdibparticipatedIssuanceQuestionValues { get; set; } = null!;
        public virtual DbSet<HdMSukukAdibparticipatedQuestionValue> HdMSukukAdibparticipatedQuestionValues { get; set; } = null!;
        public virtual DbSet<HdMSukukAdibreviewedSukukQuestionValue> HdMSukukAdibreviewedSukukQuestionValues { get; set; } = null!;
        public virtual DbSet<HdMSukukAreWeAllowedQuestionValue> HdMSukukAreWeAllowedQuestionValues { get; set; } = null!;
        public virtual DbSet<HdMSukukDocumentBasedOnQuestionValue> HdMSukukDocumentBasedOnQuestionValues { get; set; } = null!;
        public virtual DbSet<HdMSukukFatwaRequiredQuestionValue> HdMSukukFatwaRequiredQuestionValues { get; set; } = null!;
        public virtual DbSet<HdMSukukIssueAmountCurrency> HdMSukukIssueAmountCurrencies { get; set; } = null!;
        public virtual DbSet<HdMSukukObligorType> HdMSukukObligorTypes { get; set; } = null!;
        public virtual DbSet<HdMSukukOtherIslamicBank> HdMSukukOtherIslamicBanks { get; set; } = null!;
        public virtual DbSet<HdMSukukProgramSizeCurrency> HdMSukukProgramSizeCurrencies { get; set; } = null!;
        public virtual DbSet<HdMSukukTypeOfOffering> HdMSukukTypeOfOfferings { get; set; } = null!;
        public virtual DbSet<HdMSukukTypeOfProgram> HdMSukukTypeOfPrograms { get; set; } = null!;
        public virtual DbSet<HdMSukukTypeOfSukuk> HdMSukukTypeOfSukuks { get; set; } = null!;

        public virtual DbSet<HdMAdibsFeeCurrency> HdMAdibsFeeCurrencies { get; set; } = null!;
        public virtual DbSet<HdMAdibsRole> HdMAdibsRoles { get; set; } = null!;
        public virtual DbSet<HdMScoreCard> HdMScoreCards { get; set; } = null!;
        public virtual DbSet<HdMShariaStructure> HdMShariaStructure { get; set; } = null!;
        public virtual DbSet<HdMSyndAdibreviewedQuestionValue> HdMSyndAdibreviewedQuestionValues { get; set; } = null!;
        public virtual DbSet<HdMSyndAdibsParticipationCurrency> HdMSyndAdibsParticipationCurrencies { get; set; } = null!;
        public virtual DbSet<HdMSyndAdibsRole> HdMSyndAdibsRoles { get; set; } = null!;
        public virtual DbSet<HdMSyndAreWeAllowedQuestionValue> HdMSyndAreWeAllowedQuestionValues { get; set; } = null!;
        public virtual DbSet<HdMSyndClientsType> HdMSyndClientsTypes { get; set; } = null!;
        public virtual DbSet<HdMSyndDealType> HdMSyndDealTypes { get; set; } = null!;
        public virtual DbSet<HdMSyndDocumentBasedOnQuestionValue> HdMSyndDocumentBasedOnQuestionValues { get; set; } = null!;
        public virtual DbSet<HdMSyndOtherIslamicBank> HdMSyndOtherIslamicBanks { get; set; } = null!;
        public virtual DbSet<HdMSyndTransactionAmountCurrency> HdMSyndTransactionAmountCurrencies { get; set; } = null!;
        public virtual DbSet<HdMSyndTransactionType> HdMSyndTransactionTypes { get; set; } = null!;


        public virtual DbSet<HdTAnnouncement> HdTAnnouncements { get; set; } = null!;
        public virtual DbSet<HdTRequest> HdTRequests { get; set; } = null!;
        public virtual DbSet<PcMApexType> PcMApexTypes { get; set; } = null!;
        public virtual DbSet<HdTRequestDelegation> HdTRequestDelegations { get; set; } = null!;

        public virtual DbSet<HdTRequestHistory> HdTRequestHistories { get; set; } = null!;
        public virtual DbSet<HdTRequestMyTeam> HdTRequestMyTeams { get; set; } = null!;
        public virtual DbSet<HdTRequestNonAssigneeActivity> HdTRequestNonAssigneeActivities { get; set; }
        public virtual DbSet<HdTRequestQuestionAnswer> HdTRequestQuestionAnswers { get; set; } = null!;
        public virtual DbSet<HdTRequestVertexQuestionAnswer> HdTRequestVertexQuestionAnswers { get; set; } = null!;
        public virtual DbSet<HdTRequestsFieldHistory> HdTRequestsFieldHistories { get; set; } = null!;
        public virtual DbSet<HdTRequestsPeer> HdTRequestsPeers { get; set; } = null!;
        public virtual DbSet<HdTRequestsStatusTransaction> HdTRequestsStatusTransactions { get; set; } = null!;
        public virtual DbSet<HdTRequestsTemp458341f0> HdTRequestsTemp458341f0s { get; set; } = null!;
        public virtual DbSet<HdTStatusTransactionAttachment> HdTStatusTransactionAttachments { get; set; } = null!;
        public virtual DbSet<LoMAgent> LoMAgents { get; set; } = null!;
        public virtual DbSet<LoMBadge> LoMBadges { get; set; } = null!;
        public virtual DbSet<LoMCountry> LoMCountries { get; set; } = null!;
        public virtual DbSet<LoMPointsConfiguration> LoMPointsConfigurations { get; set; } = null!;
        public virtual DbSet<LoMProductMapping> LoMProductMappings { get; set; } = null!;
        public virtual DbSet<LoMProductType> LoMProductTypes { get; set; } = null!;
        public virtual DbSet<LoMRegion> LoMRegions { get; set; } = null!;
        public virtual DbSet<LoMReward> LoMRewards { get; set; } = null!;
        public virtual DbSet<LoMSalesDepartment> LoMSalesDepartments { get; set; } = null!;
        public virtual DbSet<LoMSegment> LoMSegments { get; set; } = null!;
        public virtual DbSet<LoMSpoc> LoMSpocs { get; set; } = null!;
        public virtual DbSet<LoMStatus> LoMStatuses { get; set; } = null!;
        public virtual DbSet<LoMSubsegment> LoMSubsegments { get; set; } = null!;
        public virtual DbSet<LoTEmployeePoint> LoTEmployeePoints { get; set; } = null!;
        public virtual DbSet<LoTLead> LoTLeads { get; set; } = null!;
        public virtual DbSet<LoTLeadTransaction> LoTLeadTransactions { get; set; } = null!;
        public virtual DbSet<LoTPointsTransaction> LoTPointsTransactions { get; set; } = null!;
        public virtual DbSet<LoTRedeemReward> LoTRedeemRewards { get; set; } = null!;
        public virtual DbSet<LogStream> LogStreams { get; set; } = null!;
        public virtual DbSet<LoginActivity> LoginActivities { get; set; } = null!;
        public virtual DbSet<PcMBusinessUnit> PcMBusinessUnits { get; set; } = null!;
        public virtual DbSet<PcMCategory> PcMCategories { get; set; } = null!;
        public virtual DbSet<PcMDivision> PcMDivisions { get; set; } = null!;
        public virtual DbSet<PcMOrganisation> PcMOrganisations { get; set; } = null!;
        public virtual DbSet<PcMPurpose> PcMPurposes { get; set; } = null!;
        public virtual DbSet<PcMSegment> PcMSegments { get; set; } = null!;
        public virtual DbSet<PcMShariaMode> PcMShariaModes { get; set; } = null!;
        public virtual DbSet<PcMStatus> PcMStatuses { get; set; } = null!;
        public virtual DbSet<PcMSubjectOrInstrument> PcMSubjectOrInstruments { get; set; } = null!;
        public virtual DbSet<PcMSubsidiary> PcMSubsidiaries { get; set; } = null!;
        public virtual DbSet<PcMTawazunType> PcMTawazunTypes { get; set; } = null!;
        public virtual DbSet<PcMType> PcMTypes { get; set; } = null!;
        public virtual DbSet<PcTApex> PcTApices { get; set; } = null!;
        public virtual DbSet<PcTApexAlUsoolDocument> PcTApexAlUsoolDocuments { get; set; } = null!;
        public virtual DbSet<PcTApexAttachment> PcTApexAttachments { get; set; } = null!;
        public virtual DbSet<PcTApexComplyAttachment> PcTApexComplyAttachments { get; set; } = null!;
        public virtual DbSet<PcTApexCountryGroup> PcTApexCountryGroups { get; set; } = null!;
        public virtual DbSet<PcTApexDraft> PcTApexDrafts { get; set; } = null!;
        public virtual DbSet<PcTApexFatwaLink> PcTApexFatwaLinks { get; set; } = null!;
        public virtual DbSet<PcTApexHistory> PcTApexHistories { get; set; } = null!;
        public virtual DbSet<PcTApexRequest> PcTApexRequests { get; set; } = null!;
        public virtual DbSet<PcTApexStatusTransactionAttachment> PcTApexStatusTransactionAttachments { get; set; } = null!;
        public virtual DbSet<PcTApexSupportingDocument> PcTApexSupportingDocuments { get; set; } = null!;
        public virtual DbSet<PcTApexTransaction> PcTApexTransactions { get; set; } = null!;
        public virtual DbSet<PcTRequestAlUsoolDocumentsLink> PcTRequestAlUsoolDocumentsLinks { get; set; } = null!;
        public virtual DbSet<PcTRequestApex> PcTRequestApices { get; set; } = null!;
        public virtual DbSet<PcTRequestExtendedField> PcTRequestExtendedFields { get; set; } = null!;
        public virtual DbSet<PcTRequestVarient> PcTRequestVarients { get; set; } = null!;
        public virtual DbSet<PcTTawazun> PcTTawazuns { get; set; } = null!;
        public virtual DbSet<PcTTawazunCommentsAttachment> PcTTawazunCommentsAttachments { get; set; } = null!;
        public virtual DbSet<PcTTawazunCountryGroup> PcTTawazunCountryGroups { get; set; } = null!;
        public virtual DbSet<PcTTawazunHistory> PcTTawazunHistories { get; set; } = null!;
        public virtual DbSet<PcTTawazunPackageAttachment> PcTTawazunPackageAttachments { get; set; } = null!;
        public virtual DbSet<PcTTawazunPackageParent> PcTTawazunPackageParents { get; set; } = null!;
        public virtual DbSet<PcTTawazunPackageVarient> PcTTawazunPackageVarients { get; set; } = null!;
        public virtual DbSet<PcTTawazunTransaction> PcTTawazunTransactions { get; set; } = null!;
        public virtual DbSet<PcTTawazunVarient> PcTTawazunVarients { get; set; } = null!;
        public virtual DbSet<PcTTawazunVarientAlUsoolDocument> PcTTawazunVarientAlUsoolDocuments { get; set; } = null!;
        public virtual DbSet<PcTTawazunVarientApex> PcTTawazunVarientApices { get; set; } = null!;
        public virtual DbSet<PcTTawazunVarientAttachment> PcTTawazunVarientAttachments { get; set; } = null!;
        public virtual DbSet<PcTTawazunVarientComplyAttachment> PcTTawazunVarientComplyAttachments { get; set; } = null!;
        public virtual DbSet<PcTTawazunVarientHistory> PcTTawazunVarientHistories { get; set; } = null!;
        public virtual DbSet<ReportsTable> ReportsTables { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Rolehistory> Rolehistories { get; set; } = null!;
        public virtual DbSet<SkrMNoteType> SkrMNoteTypes { get; set; } = null!;
        public virtual DbSet<SkrMReseachType> SkrMReseachTypes { get; set; } = null!;
        public virtual DbSet<SkrTAttachment> SkrTAttachments { get; set; } = null!;
        public virtual DbSet<SkrTNote> SkrTNotes { get; set; } = null!;
        public virtual DbSet<SkrTNoteTypeLog> SkrTNoteTypeLogs { get; set; } = null!;
        public virtual DbSet<SkrTNotesHistory> SkrTNotesHistories { get; set; } = null!;
        public virtual DbSet<SkrTPeer> SkrTPeers { get; set; } = null!;
        public virtual DbSet<SkrTResearchBook> SkrTResearchBooks { get; set; } = null!;
        public virtual DbSet<SkrTResearchBookTicketMapping> SkrTResearchBookTicketMappings { get; set; } = null!;
        public virtual DbSet<SkrTResearchTypeLog> SkrTResearchTypeLogs { get; set; } = null!;
        public virtual DbSet<SrMCountry> SrMCountries { get; set; } = null!;
        public virtual DbSet<SrMDocumentType> SrMDocumentTypes { get; set; } = null!;
        public virtual DbSet<SrMLanguage> SrMLanguages { get; set; } = null!;
        public virtual DbSet<SrMRegulatory> SrMRegulatories { get; set; } = null!;
        public virtual DbSet<SrMShariaModule> SrMShariaModules { get; set; } = null!;
        public virtual DbSet<SrMSubShariaModule> SrMSubShariaModules { get; set; } = null!;
        public virtual DbSet<SrTBookMarkDocument> SrTBookMarkDocuments { get; set; } = null!;
        public virtual DbSet<SrTDocumentComment> SrTDocumentComments { get; set; } = null!;
        public virtual DbSet<SrTDocumentShare> SrTDocumentShares { get; set; } = null!;
        public virtual DbSet<SrTDocumentView> SrTDocumentViews { get; set; } = null!;
        public virtual DbSet<SrTLinkedDocument> SrTLinkedDocuments { get; set; } = null!;
        public virtual DbSet<SrTShariaDocument> SrTShariaDocuments { get; set; } = null!;
        public virtual DbSet<SrTShariaDocumentHistory> SrTShariaDocumentHistories { get; set; } = null!;
        public virtual DbSet<StandardMessageMaster> StandardMessageMasters { get; set; } = null!;
        public virtual DbSet<UscAlUsool> UscAlUsools { get; set; } = null!;
        public virtual DbSet<UscMCharge> UscMCharges { get; set; } = null!;
        public virtual DbSet<UscMCriterion> UscMCriteria { get; set; } = null!;
        public virtual DbSet<UscMLoyalty> UscMLoyalties { get; set; } = null!;
        public virtual DbSet<UscMQuestion> UscMQuestions { get; set; } = null!;
        public virtual DbSet<UscMRate> UscMRates { get; set; } = null!;
        public virtual DbSet<UscMStatus> UscMStatuses { get; set; } = null!;
        public virtual DbSet<UscTCommentsVertexTransactionAttachment> UscTCommentsVertexTransactionAttachments { get; set; } = null!;
        public virtual DbSet<UscTFavouriteVertex> UscTFavouriteVertices { get; set; } = null!;
        public virtual DbSet<UscTOffer> UscTOffers { get; set; } = null!;
        public virtual DbSet<UscTOfferApproverAttachment> UscTOfferApproverAttachments { get; set; } = null!;
        public virtual DbSet<UscTOfferMakerAttachment> UscTOfferMakerAttachments { get; set; } = null!;
        public virtual DbSet<UscTOfferSliderImage> UscTOfferSliderImages { get; set; } = null!;
        public virtual DbSet<UscTOfferSupportingAttachment> UscTOfferSupportingAttachments { get; set; } = null!;
        public virtual DbSet<UscTOffersTransaction> UscTOffersTransactions { get; set; } = null!;
        public virtual DbSet<UscTOtherMediaAttachment> UscTOtherMediaAttachments { get; set; } = null!;
        public virtual DbSet<UscTProductAttachment> UscTProductAttachments { get; set; } = null!;
        public virtual DbSet<UscTProductCart> UscTProductCarts { get; set; } = null!;
        public virtual DbSet<UscTSharedLeafletVertex> UscTSharedLeafletVertices { get; set; } = null!;
        public virtual DbSet<UscTSliderImagesAttachment> UscTSliderImagesAttachments { get; set; } = null!;
        public virtual DbSet<UscTSupportingDocument> UscTSupportingDocuments { get; set; } = null!;
        public virtual DbSet<UscTVertex> UscTVertices { get; set; } = null!;
        public virtual DbSet<UscTVertexApprover> UscTVertexApprovers { get; set; } = null!;
        public virtual DbSet<UscTVertexComplyAttachment> UscTVertexComplyAttachments { get; set; } = null!;
        public virtual DbSet<UscTVertexTransaction> UscTVertexTransactions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRoleMapping> UserRoleMappings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessDeniedLog>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.CreatedBy).HasMaxLength(507);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AccessDeniedLogs)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK__AccessDen__Appli__0B9CA70C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AccessDeniedLogs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__AccessDen__UserI__0C90CB45");
            });

            modelBuilder.Entity<Application>(entity =>
            {
                entity.ToTable("Application");

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.ApplicationName).HasMaxLength(200);
            });

            modelBuilder.Entity<ApplicationModule>(entity =>
            {
                entity.ToTable("ApplicationModule");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicationName).HasMaxLength(207);
            });

            modelBuilder.Entity<ComMCountry>(entity =>
            {
                entity.ToTable("com_m_Country");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<ComTLanguage>(entity =>
            {
                entity.ToTable("com_t_Language");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<ElMBookType>(entity =>
            {
                entity.ToTable("el_m_BookType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<ElMCategory>(entity =>
            {
                entity.ToTable("el_m_Category");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArabicTitle).HasMaxLength(255);

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(255);

                entity.Property(e => e.ThumbnailUrl).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<ElMCountry>(entity =>
            {
                entity.ToTable("el_m_Countries");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<ElMLanguage>(entity =>
            {
                entity.ToTable("el_m_Languages");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<ElMSubCategory>(entity =>
            {
                entity.ToTable("el_m_SubCategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(255);

                entity.Property(e => e.ThumbnailUrl).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ElMSubCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__el_m_SubC__Categ__0D84EF7E");
            });

            modelBuilder.Entity<ElTBook>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__el_t_Boo__3DE0C227272A1688");

                entity.ToTable("el_t_Books");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.ApprovalAttachmentsUrl).HasMaxLength(450);

                entity.Property(e => e.ApproverName).HasMaxLength(255);

                entity.Property(e => e.ArabicKeywords).HasMaxLength(450);

                entity.Property(e => e.Author).HasMaxLength(255);

                entity.Property(e => e.BookTitleArabic).HasMaxLength(255);

                entity.Property(e => e.BookTitleEnglish).HasMaxLength(255);

                entity.Property(e => e.BookUrl).HasMaxLength(450);

                entity.Property(e => e.DeletedBy).HasMaxLength(255);

                entity.Property(e => e.DeletionApprovalFile).HasMaxLength(800);

                entity.Property(e => e.EnglishKeywords).HasMaxLength(450);

                entity.Property(e => e.Publication).HasMaxLength(255);

                entity.Property(e => e.ThumbnailUrl).HasMaxLength(450);

                entity.Property(e => e.UniqueFolderName).HasMaxLength(255);

                entity.Property(e => e.UploadedBy).HasMaxLength(255);

                entity.Property(e => e.Version).HasMaxLength(255);

                entity.Property(e => e.VisibilityOfBook).HasMaxLength(50);

                entity.Property(e => e.VolumeNumber).HasMaxLength(255);

                entity.HasOne(d => d.BookTypeNavigation)
                    .WithMany(p => p.ElTBooks)
                    .HasForeignKey(d => d.BookType)
                    .HasConstraintName("FK__el_t_Book__BookT__10615C29");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.ElTBooks)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("FK__el_t_Book__Categ__11558062");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.ElTBooks)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("FK__el_t_Book__Count__1249A49B");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.ElTBooks)
                    .HasForeignKey(d => d.Language)
                    .HasConstraintName("FK__el_t_Book__Langu__133DC8D4");

                entity.HasOne(d => d.SubCategoryNavigation)
                    .WithMany(p => p.ElTBooks)
                    .HasForeignKey(d => d.SubCategory)
                    .HasConstraintName("FK__el_t_Book__SubCa__1431ED0D");
            });

            modelBuilder.Entity<ElTBookMarkComment>(entity =>
            {
                entity.ToTable("el_t_BookMarkComments");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.CommentBy).HasMaxLength(255);

                entity.Property(e => e.Highlight).HasMaxLength(400);

                entity.Property(e => e.ReferMessageId).HasColumnName("ReferMessageID");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.ElTBookMarkComments)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__el_t_Book__BookI__0E7913B7");

                entity.HasOne(d => d.ReferMessage)
                    .WithMany(p => p.InverseReferMessage)
                    .HasForeignKey(d => d.ReferMessageId)
                    .HasConstraintName("FK__el_t_Book__Refer__0F6D37F0");
            });

            modelBuilder.Entity<ElTBooksHistory>(entity =>
            {
                entity.HasKey(e => e.HistoryId)
                    .HasName("PK__el_t_Boo__4D7B4ADDA848D5C4");

                entity.ToTable("el_t_BooksHistory");

                entity.Property(e => e.HistoryId).HasColumnName("HistoryID");

                entity.Property(e => e.ApprovalAttachmentsUrl).HasMaxLength(450);

                entity.Property(e => e.ApproverName).HasMaxLength(255);

                entity.Property(e => e.ArabicKeywords).HasMaxLength(450);

                entity.Property(e => e.Author).HasMaxLength(255);

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.BookTitleArabic).HasMaxLength(255);

                entity.Property(e => e.BookTitleEnglish).HasMaxLength(255);

                entity.Property(e => e.BookUrl).HasMaxLength(450);

                entity.Property(e => e.EnglishKeywords).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(500);

                entity.Property(e => e.Publication).HasMaxLength(255);

                entity.Property(e => e.ThumbnailUrl).HasMaxLength(450);

                entity.Property(e => e.UniqueFolderName).HasMaxLength(255);

                entity.Property(e => e.UploadedBy).HasMaxLength(255);

                entity.Property(e => e.Version).HasMaxLength(255);

                entity.Property(e => e.VisibilityOfBook).HasMaxLength(50);

                entity.Property(e => e.VolumeNumber).HasMaxLength(255);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.ElTBooksHistories)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__el_t_Book__BookI__15261146");

                entity.HasOne(d => d.BookTypeNavigation)
                    .WithMany(p => p.ElTBooksHistories)
                    .HasForeignKey(d => d.BookType)
                    .HasConstraintName("FK__el_t_Book__BookT__161A357F");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.ElTBooksHistories)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("FK__el_t_Book__Categ__170E59B8");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.ElTBooksHistories)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("FK__el_t_Book__Count__18027DF1");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.ElTBooksHistories)
                    .HasForeignKey(d => d.Language)
                    .HasConstraintName("FK__el_t_Book__Langu__18F6A22A");

                entity.HasOne(d => d.SubCategoryNavigation)
                    .WithMany(p => p.ElTBooksHistories)
                    .HasForeignKey(d => d.SubCategory)
                    .HasConstraintName("FK__el_t_Book__SubCa__19EAC663");
            });

            modelBuilder.Entity<ElTFavouriteBook>(entity =>
            {
                entity.ToTable("el_t_FavouriteBooks");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.UserEmail).HasMaxLength(255);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.ElTFavouriteBooks)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__el_t_Favo__BookI__1ADEEA9C");
            });

            modelBuilder.Entity<ElTLinkedBook>(entity =>
            {
                entity.ToTable("el_t_LinkedBooks");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.ReferBookId).HasColumnName("ReferBookID");

                entity.HasOne(d => d.ReferBook)
                    .WithMany(p => p.ElTLinkedBooks)
                    .HasForeignKey(d => d.ReferBookId)
                    .HasConstraintName("FK__el_t_Link__Refer__1BD30ED5");
            });

            modelBuilder.Entity<ElTRecentView>(entity =>
            {
                entity.ToTable("el_t_RecentViews");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.UserEmail).HasMaxLength(255);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.ElTRecentViews)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__el_t_Rece__BookI__1CC7330E");
            });

            modelBuilder.Entity<EmailNotificationsMaster>(entity =>
            {
                entity.ToTable("EmailNotificationsMaster");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BodyArabic).HasColumnName("Body_Arabic");

                entity.Property(e => e.BodyEnglish).HasColumnName("Body_English");
            });

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Apiurl)
                    .HasMaxLength(255)
                    .HasColumnName("APIUrl");

                entity.Property(e => e.Host).HasMaxLength(255);

                entity.Property(e => e.MethodType).HasMaxLength(255);

                entity.Property(e => e.Path).HasMaxLength(255);

                entity.Property(e => e.Source).HasMaxLength(255);
            });

            modelBuilder.Entity<HdMArea>(entity =>
            {
                entity.HasKey(e => e.AreaId)
                    .HasName("PK__hd_m_Are__70B82028FE3D9966");

                entity.ToTable("hd_m_Area");

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.Property(e => e.ArabicTitle).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.Property(e => e.UserId)
                    .HasMaxLength(200)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<HdMBranch>(entity =>
            {
                entity.HasKey(e => e.BranchId)
                    .HasName("PK__hd_m_Bra__A1682FA501CA2BB4");

                entity.ToTable("hd_m_Branch");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__hd_m_Cat__19093A2BCC15E342");

                entity.ToTable("hd_m_Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMDepartment>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("PK__hd_m_Dep__B2079BCDE7E898F5");

                entity.ToTable("hd_m_Department");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMEmailTemplate>(entity =>
            {
                entity.ToTable("hd_m_EmailTemplate");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArabicTemplate).HasMaxLength(500);

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.EmailParameters).HasMaxLength(500);

                entity.Property(e => e.EnglishTemplate).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);

                entity.Property(e => e.TemplateName).HasMaxLength(200);
            });

            modelBuilder.Entity<HdMHoliday>(entity =>
            {
                entity.HasKey(e => e.HolidayId)
                    .HasName("PK__hd_m_Hol__2D35D59A1A9D1A88");

                entity.ToTable("hd_m_Holidays");

                entity.Property(e => e.HolidayId).HasColumnName("HolidayID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__hd_m_Pro__B40CC6EDFADAB31D");

                entity.ToTable("hd_m_Product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.HdMProducts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__hd_m_Prod__Categ__1DBB5747");
            });

            modelBuilder.Entity<HdMQuestion>(entity =>
            {
                entity.HasKey(e => e.QuestionId)
                    .HasName("PK__hd_m_Que__0DC06F8CF000CA1F");

                entity.ToTable("hd_m_Questions");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.IsMandatory).HasColumnName("isMandatory");

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);

                entity.Property(e => e.SubProductId).HasColumnName("SubProductID");

                entity.HasOne(d => d.SubProduct)
                    .WithMany(p => p.HdMQuestions)
                    .HasForeignKey(d => d.SubProductId)
                    .HasConstraintName("fk_hd_m_SubProduct_SubProductID");
            });

            modelBuilder.Entity<HdMRequestType>(entity =>
            {
                entity.HasKey(e => e.RequestTypeId)
                    .HasName("PK__hd_m_Req__4D328BA3754FC24E");

                entity.ToTable("hd_m_RequestType");

                entity.Property(e => e.RequestTypeId).HasColumnName("RequestTypeID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);

                entity.Property(e => e.Role).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(300);

                entity.Property(e => e.TitleArabic).HasMaxLength(300);

            });

            modelBuilder.Entity<HdMResearchType>(entity =>
            {
                entity.ToTable("hd_m_ResearchType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMShariaStaff>(entity =>
            {
                entity.ToTable("hd_m_ShariaStaff");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BackupStaff).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);

                entity.Property(e => e.Staff).HasMaxLength(200);
            });

            modelBuilder.Entity<HdMStatus>(entity =>
            {
                entity.ToTable("hd_m_Status");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.RoleBy).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.Property(e => e.ValuePair).HasMaxLength(200);
            });

            modelBuilder.Entity<HdMSubProduct>(entity =>
            {
                entity.HasKey(e => e.SubProductId)
                    .HasName("PK__hd_m_Sub__65C91845D2733117");

                entity.ToTable("hd_m_SubProduct");

                entity.Property(e => e.SubProductId).HasColumnName("SubProductID");

                entity.Property(e => e.ArabicTitle).HasMaxLength(300);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Title).HasMaxLength(300);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.HdMSubProducts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__hd_m_SubP__Categ__6FE99F9F");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.HdMSubProducts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__hd_m_SubP__Produ__6EF57B66");
            });


            modelBuilder.Entity<HdMSukukAdibparticipatedIssuanceQuestionValue>(entity =>
            {
                entity.ToTable("hd_m_Sukuk_ADIBParticipatedIssuance_QuestionValues");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMSukukAdibparticipatedQuestionValue>(entity =>
            {
                entity.ToTable("hd_m_Sukuk_ADIBParticipated_QuestionValues");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMSukukAdibreviewedSukukQuestionValue>(entity =>
            {
                entity.ToTable("hd_m_Sukuk_ADIBReviewedSukuk_QuestionValues");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMSukukAreWeAllowedQuestionValue>(entity =>
            {
                entity.ToTable("hd_m_Sukuk_AreWeAllowed_QuestionValues");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMSukukDocumentBasedOnQuestionValue>(entity =>
            {
                entity.ToTable("hd_m_Sukuk_DocumentBasedOn_QuestionValues");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMSukukFatwaRequiredQuestionValue>(entity =>
            {
                entity.ToTable("hd_m_Sukuk_FatwaRequired_QuestionValues");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMSukukIssueAmountCurrency>(entity =>
            {
                entity.ToTable("hd_m_Sukuk_IssueAmountCurrency");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMSukukObligorType>(entity =>
            {
                entity.ToTable("hd_m_Sukuk_ObligorType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMSukukOtherIslamicBank>(entity =>
            {
                entity.ToTable("hd_m_Sukuk_OtherIslamicBanks");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMSukukProgramSizeCurrency>(entity =>
            {
                entity.ToTable("hd_m_Sukuk_ProgramSizeCurrency");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMSukukTypeOfOffering>(entity =>
            {
                entity.ToTable("hd_m_Sukuk_TypeOfOffering");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMSukukTypeOfProgram>(entity =>
            {
                entity.ToTable("hd_m_Sukuk_TypeOfProgram");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMSukukTypeOfSukuk>(entity =>
            {
                entity.ToTable("hd_m_Sukuk_TypeOfSukuk");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMWorkingShift>(entity =>
            {
                entity.ToTable("hd_m_WorkingShifts");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.ExpResponse).HasMaxLength(200);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);

                entity.Property(e => e.ShiftName).HasMaxLength(200);
            });


            modelBuilder.Entity<HdMScoreCard>(entity =>
            {
                entity.ToTable("hd_m_ScoreCard");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });


            modelBuilder.Entity<HdMShariaStructure>(entity =>
            {
                entity.ToTable("hd_m_ShariaStructure");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMAdibsFeeCurrency>(entity =>
            {
                entity.ToTable("hd_m_ADIBsFeeCurrency");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMAdibsRole>(entity =>
            {
                entity.ToTable("hd_m_ADIBsRole");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });


            modelBuilder.Entity<HdMSyndAdibreviewedQuestionValue>(entity =>
            {
                entity.ToTable("hd_m_Synd_ADIBReviewed_QuestionValues");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMSyndAdibsParticipationCurrency>(entity =>
            {
                entity.ToTable("hd_m_Synd_ADIBsParticipationCurrency");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMSyndAdibsRole>(entity =>
            {
                entity.ToTable("hd_m_Synd_ADIBsRole");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMSyndAreWeAllowedQuestionValue>(entity =>
            {
                entity.ToTable("hd_m_Synd_AreWeAllowed_QuestionValues");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMSyndClientsType>(entity =>
            {
                entity.ToTable("hd_m_Synd_ClientsType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMSyndDealType>(entity =>
            {
                entity.ToTable("hd_m_Synd_DealType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMSyndDocumentBasedOnQuestionValue>(entity =>
            {
                entity.ToTable("hd_m_Synd_DocumentBasedOn_QuestionValues");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMSyndOtherIslamicBank>(entity =>
            {
                entity.ToTable("hd_m_Synd_OtherIslamicBanks");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMSyndTransactionAmountCurrency>(entity =>
            {
                entity.ToTable("hd_m_Synd_TransactionAmountCurrency");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdMSyndTransactionType>(entity =>
            {
                entity.ToTable("hd_m_Synd_TransactionType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);
            });

            modelBuilder.Entity<HdTAnnouncement>(entity =>
            {
                entity.ToTable("hd_t_Announcements");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Announcement).HasMaxLength(300);

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.FileName).HasMaxLength(500);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<HdTRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__hd_t_Req__33A8519ABB3CEDC4");

                entity.ToTable("hd_t_Requests");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.BranchName).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.CurrentRequestOwner).HasMaxLength(324);

                entity.Property(e => e.CustomRequestId).HasMaxLength(100);

                entity.Property(e => e.CustomerName).HasMaxLength(200);

                entity.Property(e => e.CustomerPhoneNumber).HasMaxLength(50);

                entity.Property(e => e.CustomerRimnumber)
                    .HasMaxLength(200)
                    .HasColumnName("CustomerRIMNumber");

                entity.Property(e => e.DepartmentName).HasMaxLength(200);

                entity.Property(e => e.FinanceNumber).HasMaxLength(200);

                entity.Property(e => e.History).HasMaxLength(200);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(200);

                entity.Property(e => e.NotesWithoutHtml).HasColumnName("Notes_WithoutHTML");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.RequesterId)
                    .HasMaxLength(324)
                    .HasColumnName("RequesterID");

                entity.Property(e => e.RequesterName).HasMaxLength(200);

                entity.Property(e => e.ShariaExpert).HasMaxLength(200);

                entity.Property(e => e.Status).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.HasOne(d => d.AreaNavigation)
                    .WithMany(p => p.HdTRequests)
                    .HasForeignKey(d => d.Area)
                    .HasConstraintName("FK__hd_t_Reque__Area__2FDA0782");

                entity.HasOne(d => d.BranchNavigation)
                    .WithMany(p => p.HdTRequests)
                    .HasForeignKey(d => d.Branch)
                    .HasConstraintName("FK__hd_t_Requ__Branc__2B155265");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.HdTRequests)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("fk_hd_m_Category_Category");

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.HdTRequests)
                    .HasForeignKey(d => d.Department)
                    .HasConstraintName("FK__hd_t_Requ__Depar__2CFD9AD7");

                entity.HasOne(d => d.OriginalCategoryNavigation)
                    .WithMany(p => p.HdTRequests)
                    .HasForeignKey(d => d.OriginalCategory)
                    .HasConstraintName("FK__hd_t_Requ__Origi__4E347170");

                entity.HasOne(d => d.OriginalProductNavigation)
                    .WithMany(p => p.HdTRequests)
                    .HasForeignKey(d => d.OriginalProduct)
                    .HasConstraintName("FK__hd_t_Requ__Origi__4F2895A9");

                entity.HasOne(d => d.OriginalSubProductNavigation)
                    .WithMany(p => p.HdTRequests)
                    .HasForeignKey(d => d.OriginalSubProduct)
                    .HasConstraintName("FK__hd_t_Requ__Origi__501CB9E2");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.HdTRequests)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("fk_hd_m_Product_Product");

                entity.HasOne(d => d.RequestTypeNavigation)
                    .WithMany(p => p.HdTRequests)
                    .HasForeignKey(d => d.RequestType)
                    .HasConstraintName("fk_hd_m_RequestType_RequestType");

                entity.HasOne(d => d.SubProductNavigation)
                    .WithMany(p => p.HdTRequests)
                    .HasForeignKey(d => d.SubProduct)
                    .HasConstraintName("fk_hd_m_SubProduct_SubProduct");
            });

            modelBuilder.Entity<HdTRequestHistory>(entity =>
            {
                entity.HasKey(e => e.HistoryId)
                    .HasName("PK__hd_t_Req__4D7B4ADD4C377B8D");

                entity.ToTable("hd_t_RequestHistory");

                entity.Property(e => e.HistoryId).HasColumnName("HistoryID");

                entity.Property(e => e.BranchName).HasMaxLength(300);

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.CurrentRequestOwner).HasMaxLength(324);

                entity.Property(e => e.CustomerName).HasMaxLength(200);

                entity.Property(e => e.CustomerPhoneNumber).HasMaxLength(50);

                entity.Property(e => e.CustomerRimnumber)
                    .HasMaxLength(50)
                    .HasColumnName("CustomerRIMNumber");

                entity.Property(e => e.DepartmentName).HasMaxLength(300);

                entity.Property(e => e.FinanceNumber).HasMaxLength(50);

                entity.Property(e => e.History).HasMaxLength(500);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(200);

                entity.Property(e => e.LegalAssignedTo).HasMaxLength(500);

                entity.Property(e => e.LegalStatus).HasMaxLength(100);

                entity.Property(e => e.ModifiedTawazunId).HasColumnName("ModifiedTawazunID");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.ProductApprovalId).HasColumnName("ProductApprovalID");

                entity.Property(e => e.ProductConceptApprovalId).HasColumnName("ProductConceptApprovalID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.RequesterId)
                    .HasMaxLength(324)
                    .HasColumnName("RequesterID");

                entity.Property(e => e.RequesterName).HasMaxLength(200);

                entity.Property(e => e.ShariaExpert).HasMaxLength(500);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.HasOne(d => d.AreaNavigation)
                    .WithMany(p => p.HdTRequestHistories)
                    .HasForeignKey(d => d.Area)
                    .HasConstraintName("FK__hd_t_Reque__Area__2744C181");

                entity.HasOne(d => d.BranchNavigation)
                    .WithMany(p => p.HdTRequestHistories)
                    .HasForeignKey(d => d.Branch)
                    .HasConstraintName("FK__hd_t_Requ__Branc__218BE82B");

                entity.HasOne(d => d.BusinessUnitNavigation)
                    .WithMany(p => p.HdTRequestHistories)
                    .HasForeignKey(d => d.BusinessUnit)
                    .HasConstraintName("FK__hd_t_Requ__Busin__3528CC84");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.HdTRequestHistories)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("FK__hd_t_Requ__Categ__53ED4AC6");

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.HdTRequestHistories)
                    .HasForeignKey(d => d.Department)
                    .HasConstraintName("FK__hd_t_Requ__Depar__2374309D");

                entity.HasOne(d => d.DivisionNavigation)
                    .WithMany(p => p.HdTRequestHistories)
                    .HasForeignKey(d => d.Division)
                    .HasConstraintName("FK__hd_t_Requ__Divis__361CF0BD");

                entity.HasOne(d => d.OrganisationsNavigation)
                    .WithMany(p => p.HdTRequestHistories)
                    .HasForeignKey(d => d.Organisations)
                    .HasConstraintName("FK__hd_t_Requ__Organ__3434A84B");

                entity.HasOne(d => d.OriginalCategoryNavigation)
                    .WithMany(p => p.HdTRequestHistoryOriginalCategoryNavigations)
                    .HasForeignKey(d => d.OriginalCategory)
                    .HasConstraintName("FK__hd_t_Requ__Origi__5110DE1B");

                entity.HasOne(d => d.OriginalProductNavigation)
                    .WithMany(p => p.HdTRequestHistories)
                    .HasForeignKey(d => d.OriginalProduct)
                    .HasConstraintName("FK__hd_t_Requ__Origi__52050254");

                entity.HasOne(d => d.OriginalSubProductNavigation)
                    .WithMany(p => p.HdTRequestHistories)
                    .HasForeignKey(d => d.OriginalSubProduct)
                    .HasConstraintName("FK__hd_t_Requ__Origi__52F9268D");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.HdTRequestHistories)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK__hd_t_Requ__Produ__54E16EFF");

                entity.HasOne(d => d.PurposeNavigation)
                    .WithMany(p => p.HdTRequestHistories)
                    .HasForeignKey(d => d.Purpose)
                    .HasConstraintName("FK__hd_t_Requ__Purpo__371114F6");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.HdTRequestHistories)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__hd_t_Requ__Reque__255C790F");

                entity.HasOne(d => d.RequestTypeNavigation)
                    .WithMany(p => p.HdTRequestHistories)
                    .HasForeignKey(d => d.RequestType)
                    .HasConstraintName("fk_hd_m_RequestType_Requesthist");

                entity.HasOne(d => d.SegmentNavigation)
                    .WithMany(p => p.HdTRequestHistorySegmentNavigations)
                    .HasForeignKey(d => d.Segment)
                    .HasConstraintName("FK__hd_t_Requ__Segme__33408412");

                entity.HasOne(d => d.ShariaModeNavigation)
                    .WithMany(p => p.HdTRequestHistories)
                    .HasForeignKey(d => d.ShariaMode)
                    .HasConstraintName("FK__hd_t_Requ__Shari__3805392F");

                entity.HasOne(d => d.SubProductNavigation)
                    .WithMany(p => p.HdTRequestHistories)
                    .HasForeignKey(d => d.SubProduct)
                    .HasConstraintName("FK__hd_t_Requ__SubPr__55D59338");

                entity.HasOne(d => d.SubSidiaryNavigation)
                    .WithMany(p => p.HdTRequestHistories)
                    .HasForeignKey(d => d.SubSidiary)
                    .HasConstraintName("FK__hd_t_Requ__SubSi__31233176");

                entity.HasOne(d => d.SubjectOrInstrumentNavigation)
                    .WithMany(p => p.HdTRequestHistories)
                    .HasForeignKey(d => d.SubjectOrInstrument)
                    .HasConstraintName("FK__hd_t_Requ__Subje__38F95D68");
            });

            modelBuilder.Entity<HdTRequestMyTeam>(entity =>
            {
                entity.ToTable("hd_t_RequestMyTeams");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.EmailId).HasMaxLength(500);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.HdTRequestMyTeams)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__hd_t_Requ__Reque__6DD739FB");
            });

            modelBuilder.Entity<HdTRequestNonAssigneeActivity>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__hd_t_Req__3214EC077E693CBC");

                entity.ToTable("hd_t_RequestNonAssigneeActivity");

                entity.Property(e => e.ActingUser).HasMaxLength(500);
                entity.Property(e => e.ActionPerformedStatus).HasMaxLength(200);
                entity.Property(e => e.CurrentAssignee).HasMaxLength(500);
                entity.Property(e => e.PreviousStatus).HasMaxLength(200);
                entity.Property(e => e.Role).HasMaxLength(200);
            });

            modelBuilder.Entity<PcMApexType>(entity =>
            {
                entity.ToTable("pc_m_ApexType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);
            });

            modelBuilder.Entity<HdTRequestDelegation>(entity =>
            {
                entity.ToTable("hd_t_RequestDelegation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DelegatedBy).HasMaxLength(324);

                entity.Property(e => e.DelegatedTo).HasMaxLength(324);

                entity.Property(e => e.RequestId).HasColumnName("RequestID");
            });

            modelBuilder.Entity<HdTRequestQuestionAnswer>(entity =>
            {
                entity.ToTable("hd_t_RequestQuestionAnswers");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.HdTRequestQuestionAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__hd_t_Requ__Quest__292D09F3");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.HdTRequestQuestionAnswers)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__hd_t_Requ__Reque__2A212E2C");
            });

            modelBuilder.Entity<HdTRequestVertexQuestionAnswer>(entity =>
            {
                entity.ToTable("hd_t_RequestVertexQuestionAnswers");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.HdTRequestVertexQuestionAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__hd_t_Requ__Quest__4A63E08C");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.HdTRequestVertexQuestionAnswers)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__hd_t_Requ__Reque__496FBC53");
            });

            modelBuilder.Entity<HdTRequestsFieldHistory>(entity =>
            {
                entity.ToTable("hd_t_RequestsFieldHistory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);
            });

            modelBuilder.Entity<HdTRequestsPeer>(entity =>
            {
                entity.ToTable("hd_t_RequestsPeer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddedBy).HasMaxLength(200);

                entity.Property(e => e.PeersEmailId)
                    .HasMaxLength(500)
                    .HasColumnName("PeersEmailID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.HdTRequestsPeers)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__hd_t_Requ__Reque__31C24FF4");
            });

            modelBuilder.Entity<HdTRequestsStatusTransaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PK__hd_t_Req__55433A4B8CF31BE1");

                entity.ToTable("hd_t_RequestsStatusTransactions");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.FromPersonId)
                    .HasMaxLength(324)
                    .HasColumnName("FromPersonID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.ToPersonId)
                    .HasMaxLength(324)
                    .HasColumnName("ToPersonID");

                entity.Property(e => e.TransactionBy).HasMaxLength(500);

                entity.Property(e => e.TransactionByDisplayName)
                    .HasMaxLength(300)
                    .HasColumnName("TransactionBy_DisplayName");

                entity.Property(e => e.TransactionByRole)
                    .HasMaxLength(300)
                    .HasColumnName("TransactionBy_Role");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.HdTRequestsStatusTransactions)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__hd_t_Requ__Reque__32B6742D");
            });

            modelBuilder.Entity<HdTRequestsTemp458341f0>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hd_t_RequestsTemp458341f0");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.CurrentRequestOwner).HasMaxLength(324);

                entity.Property(e => e.CustomerName).HasMaxLength(200);

                entity.Property(e => e.CustomerPhoneNumber).HasMaxLength(50);

                entity.Property(e => e.CustomerRimnumber)
                    .HasMaxLength(200)
                    .HasColumnName("CustomerRIMNumber");

                entity.Property(e => e.FinanceNumber).HasMaxLength(200);

                entity.Property(e => e.History).HasMaxLength(200);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(200);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.RequesterId)
                    .HasMaxLength(324)
                    .HasColumnName("RequesterID");

                entity.Property(e => e.RequesterName).HasMaxLength(200);

                entity.Property(e => e.ShariaExpert).HasMaxLength(200);

                entity.Property(e => e.Status).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<HdTStatusTransactionAttachment>(entity =>
            {
                entity.HasKey(e => e.AttachmentId)
                    .HasName("PK__hd_t_Sta__442C64DE9FD3972F");

                entity.ToTable("hd_t_StatusTransactionAttachments");

                entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");

                entity.Property(e => e.FileName).HasMaxLength(300);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.UploadedBy).HasMaxLength(200);

                entity.Property(e => e.Url).HasColumnName("URL");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.HdTStatusTransactionAttachments)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__hd_t_Stat__Reque__33AA9866");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.HdTStatusTransactionAttachments)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK__hd_t_Stat__Trans__349EBC9F");
            });

            modelBuilder.Entity<LoMAgent>(entity =>
            {
                entity.ToTable("lo_m_Agents");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(500)
                    .HasColumnName("EmailID");

                entity.HasOne(d => d.SalesDepartmentNavigation)
                    .WithMany(p => p.LoMAgents)
                    .HasForeignKey(d => d.SalesDepartment)
                    .HasConstraintName("FK__lo_m_Agen__Sales__3469B275");
            });

            modelBuilder.Entity<LoMBadge>(entity =>
            {
                entity.ToTable("lo_m_Badges");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.Points).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(300);
            });

            modelBuilder.Entity<LoMCountry>(entity =>
            {
                entity.ToTable("lo_m_Country");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryCode).HasMaxLength(500);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);
            });

            modelBuilder.Entity<LoMPointsConfiguration>(entity =>
            {
                entity.ToTable("lo_m_PointsConfigurations");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.Points).HasMaxLength(200);

                entity.Property(e => e.Product).HasMaxLength(1000);

                entity.Property(e => e.Stage).HasMaxLength(200);
            });

            modelBuilder.Entity<LoMProductMapping>(entity =>
            {
                entity.ToTable("lo_m_ProductMapping");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Product).HasMaxLength(1000);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.ProductTypeNavigation)
                    .WithMany(p => p.LoMProductMappings)
                    .HasForeignKey(d => d.ProductType)
                    .HasConstraintName("FK__lo_m_Prod__Produ__3651FAE7");
            });

            modelBuilder.Entity<LoMProductType>(entity =>
            {
                entity.ToTable("lo_m_ProductType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Type).HasMaxLength(207);
            });

            modelBuilder.Entity<LoMRegion>(entity =>
            {
                entity.ToTable("lo_m_Region");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(300);

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.LoMRegions)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("FK__lo_m_Regi__Count__37461F20");
            });

            modelBuilder.Entity<LoMReward>(entity =>
            {
                entity.ToTable("lo_m_Rewards");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttachmentUrl).HasMaxLength(500);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(300);

                entity.Property(e => e.RequiredPoints).HasMaxLength(200);

                entity.Property(e => e.ValidFrom).HasColumnName("validFrom");
            });

            modelBuilder.Entity<LoMSalesDepartment>(entity =>
            {
                entity.ToTable("lo_m_SalesDepartment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(300);
            });

            modelBuilder.Entity<LoMSegment>(entity =>
            {
                entity.ToTable("lo_m_Segment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<LoMSpoc>(entity =>
            {
                entity.ToTable("lo_m_SPOCS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(500)
                    .HasColumnName("EmailID");

                entity.HasOne(d => d.SalesDepartmentNavigation)
                    .WithMany(p => p.LoMSpocs)
                    .HasForeignKey(d => d.SalesDepartment)
                    .HasConstraintName("FK__lo_m_SPOC__Sales__383A4359");
            });

            modelBuilder.Entity<LoMStatus>(entity =>
            {
                entity.ToTable("lo_m_Status");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.RoleBy).HasMaxLength(200);

                entity.Property(e => e.StatusName).HasMaxLength(200);

                entity.Property(e => e.ValuePair).HasMaxLength(200);
            });

            modelBuilder.Entity<LoMSubsegment>(entity =>
            {
                entity.ToTable("lo_m_Subsegment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttachmentUrl)
                    .HasMaxLength(500)
                    .HasColumnName("AttachmentURL");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.FileName).HasMaxLength(300);

                entity.Property(e => e.FilePath).HasMaxLength(300);

                entity.Property(e => e.FileSize).HasMaxLength(200);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(300);
            });

            modelBuilder.Entity<LoTEmployeePoint>(entity =>
            {
                entity.ToTable("lo_t_EmployeePoints");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AllTimePoints).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(500)
                    .HasColumnName("EmailID");

                entity.Property(e => e.Points).HasMaxLength(200);

                entity.Property(e => e.RedeemedPoints).HasMaxLength(500);
            });

            modelBuilder.Entity<LoTLead>(entity =>
            {
                entity.ToTable("lo_t_Leads");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttachmentUrl).HasMaxLength(500);

                entity.Property(e => e.ContactNmber).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.CustomLeadId)
                    .HasMaxLength(150)
                    .HasColumnName("CustomLeadID");

                entity.Property(e => e.EmailId).HasMaxLength(500);

                entity.Property(e => e.FullName).HasMaxLength(300);

                entity.Property(e => e.IncomeRange).HasMaxLength(200);

                entity.Property(e => e.InvestmentAmount).HasMaxLength(200);

                entity.Property(e => e.PreferredTimeToCall).HasMaxLength(200);

                entity.Property(e => e.Product).HasMaxLength(1000);

                entity.Property(e => e.Sources).HasMaxLength(300);

                entity.Property(e => e.Spoc).HasColumnName("SPOC");

                entity.Property(e => e.StatusName).HasMaxLength(100);

                entity.HasOne(d => d.RegionNavigation)
                    .WithMany(p => p.LoTLeads)
                    .HasForeignKey(d => d.Region)
                    .HasConstraintName("FK__lo_t_Lead__Regio__3A228BCB");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.LoTLeads)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK__lo_t_Lead__Statu__3B16B004");
            });

            modelBuilder.Entity<LoTLeadTransaction>(entity =>
            {
                entity.ToTable("lo_t_LeadTransaction");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.LeadId).HasColumnName("LeadID");

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.LoTLeadTransactions)
                    .HasForeignKey(d => d.LeadId)
                    .HasConstraintName("FK__lo_t_Lead__LeadI__3C0AD43D");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.LoTLeadTransactions)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__lo_t_Lead__Statu__3DF31CAF");
            });

            modelBuilder.Entity<LoTPointsTransaction>(entity =>
            {
                entity.ToTable("lo_t_pointsTransactions");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.Points).HasMaxLength(200);

                entity.Property(e => e.Users).HasMaxLength(500);

                entity.HasOne(d => d.LeadNavigation)
                    .WithMany(p => p.LoTPointsTransactions)
                    .HasForeignKey(d => d.Lead)
                    .HasConstraintName("FK__lo_t_point__Lead__3EE740E8");
            });

            modelBuilder.Entity<LoTRedeemReward>(entity =>
            {
                entity.ToTable("lo_t_RedeemRewards");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttachmentUrl).HasMaxLength(500);

                entity.Property(e => e.Comments).HasMaxLength(800);

                entity.Property(e => e.Offer).HasMaxLength(300);

                entity.Property(e => e.OfferId).HasColumnName("OfferID");

                entity.Property(e => e.RequestBy).HasMaxLength(500);

                entity.Property(e => e.RequesterName).HasMaxLength(200);

                entity.Property(e => e.Status).HasMaxLength(100);
            });

            modelBuilder.Entity<LogStream>(entity =>
            {
                entity.ToTable("LogStream");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Log).HasMaxLength(200);
            });

            modelBuilder.Entity<LoginActivity>(entity =>
            {
                entity.ToTable("LoginActivity");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicationName).HasMaxLength(200);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(507)
                    .HasColumnName("EmailID");
            });

            modelBuilder.Entity<PcMBusinessUnit>(entity =>
            {
                entity.ToTable("pc_m_BusinessUnit");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);
            });

            modelBuilder.Entity<PcMCategory>(entity =>
            {
                entity.ToTable("pc_m_Category");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.HasOne(d => d.SegmentNavigation)
                    .WithMany(p => p.PcMCategories)
                    .HasForeignKey(d => d.Segment)
                    .HasConstraintName("FK__pc_m_Cate__Segme__5BC376B8");
            });

            modelBuilder.Entity<PcMDivision>(entity =>
            {
                entity.ToTable("pc_m_Division");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);
            });

            modelBuilder.Entity<PcMOrganisation>(entity =>
            {
                entity.ToTable("pc_m_Organisations");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryCode).HasMaxLength(500);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);
            });

            modelBuilder.Entity<PcMPurpose>(entity =>
            {
                entity.ToTable("pc_m_Purpose");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);
            });

            modelBuilder.Entity<PcMSegment>(entity =>
            {
                entity.ToTable("pc_m_Segment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<PcMShariaMode>(entity =>
            {
                entity.ToTable("pc_m_ShariaMode");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);
            });

            modelBuilder.Entity<PcMStatus>(entity =>
            {
                entity.ToTable("pc_m_Status");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RoleBy).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.Property(e => e.ValuePair).HasMaxLength(200);
            });

            modelBuilder.Entity<PcMSubjectOrInstrument>(entity =>
            {
                entity.ToTable("pc_m_Subject_or_Instrument");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);
            });

            modelBuilder.Entity<PcMSubsidiary>(entity =>
            {
                entity.ToTable("pc_m_Subsidiary");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.HasOne(d => d.Organisation)
                    .WithMany(p => p.PcMSubsidiaries)
                    .HasForeignKey(d => d.OrganisationId)
                    .HasConstraintName("FK__pc_m_Subs__Organ__0E4EF685");
            });

            modelBuilder.Entity<PcMTawazunType>(entity =>
            {
                entity.ToTable("pc_m_TawazunType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PcMType>(entity =>
            {
                entity.ToTable("pc_m_Type");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);
            });

            modelBuilder.Entity<PcTApex>(entity =>
            {
                entity.ToTable("pc_t_Apex");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApexCountryGroups).HasColumnName("Apex_country_groups");

                entity.Property(e => e.ApexOwner).HasMaxLength(400);

                entity.Property(e => e.CompliedBy).HasMaxLength(500);

                entity.Property(e => e.CompliedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.CustomApexId).HasMaxLength(100);

                entity.Property(e => e.DescriptionWithoutHtml).HasColumnName("Description_WithoutHTML");

                entity.Property(e => e.LastmodifiedBy).HasMaxLength(500);
 
                entity.Property(e => e.Organisation).HasColumnName("organisation");

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.HasOne(d => d.PurposeNavigation)
                    .WithMany(p => p.PcTApices)
                    .HasForeignKey(d => d.Purpose)
                    .HasConstraintName("FK__pc_t_Apex__Purpo__092A4EB5");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.PcTApices)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("FK__pc_t_Apex__Type__0C06BB60");
            });


            modelBuilder.Entity<PcTApexAlUsoolDocument>(entity =>
            {
                entity.ToTable("pc_t_Apex_AlUsool_Documents");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApexId).HasColumnName("ApexID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(255);

                entity.Property(e => e.DocumentName).HasMaxLength(500);

                entity.Property(e => e.DocumentType).HasMaxLength(500);

                entity.Property(e => e.ObjectId).HasMaxLength(200);

                entity.Property(e => e.SearchBy).HasMaxLength(500);

                entity.Property(e => e.Status).HasMaxLength(255);
            });

            modelBuilder.Entity<PcTApexAttachment>(entity =>
            {
                entity.ToTable("pc_t_ApexAttachments");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApexId).HasColumnName("ApexID");

                entity.Property(e => e.AttachmentUrl)
                    .HasMaxLength(500)
                    .HasColumnName("AttachmentURL");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(255);

                entity.Property(e => e.FileName).HasMaxLength(200);

                entity.Property(e => e.Size).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(255);
            });

            modelBuilder.Entity<PcTApexComplyAttachment>(entity =>
            {
                entity.ToTable("pc_t_ApexComplyAttachments");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApexId).HasColumnName("ApexID");

                entity.Property(e => e.AttachmentUrl)
                    .HasMaxLength(500)
                    .HasColumnName("AttachmentURL");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(255);

                entity.Property(e => e.FileName).HasMaxLength(200);

                entity.Property(e => e.Size).HasMaxLength(100);
            });

            modelBuilder.Entity<PcTApexCountryGroup>(entity =>
            {
                entity.HasKey(e => e.Groupid)
                    .HasName("PK__pc_t_Ape__88C40F85999280C1");

                entity.ToTable("pc_t_Apex_country_groups");

                entity.Property(e => e.Groupid).HasColumnName("groupid");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Groupname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("groupname");
            });


            modelBuilder.Entity<PcTApexDraft>(entity =>
            {
                entity.ToTable("pc_t_ApexDrafts");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AlUsoolDocumentsJson).HasColumnName("AlUsool_DocumentsJson");

                entity.Property(e => e.ApexOwner).HasMaxLength(400);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.CustomApexId).HasMaxLength(100);

                entity.Property(e => e.LastmodifiedBy).HasMaxLength(500);

                entity.Property(e => e.ModificationApprovalProof).HasMaxLength(500);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.ApexCountryGroups).HasColumnName("Apex_country_groups");
                entity.Property(e => e.Organisation).HasColumnName("organisation");
            });

            modelBuilder.Entity<PcTApexFatwaLink>(entity =>
            {
                entity.ToTable("pc_t_Apex_FatwaLinks");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApexId).HasColumnName("ApexID");

                entity.Property(e => e.AttachmentUrl)
                    .HasMaxLength(500)
                    .HasColumnName("AttachmentURL");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(400);
            });

            modelBuilder.Entity<PcTApexHistory>(entity =>
            {
                entity.ToTable("pc_t_ApexHistory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApexId).HasColumnName("ApexID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.ModificationApprovalProof).HasMaxLength(500);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.ApexCountryGroups).HasColumnName("Apex_country_groups");
                entity.Property(e => e.Organisation).HasColumnName("organisation");

                entity.HasOne(d => d.Apex)
                    .WithMany(p => p.PcTApexHistories)
                    .HasForeignKey(d => d.ApexId)
                    .HasConstraintName("FK__pc_t_Apex__ApexI__08CB2759");

                entity.HasOne(d => d.PurposeNavigation)
                    .WithMany(p => p.PcTApexHistories)
                    .HasForeignKey(d => d.Purpose)
                    .HasConstraintName("FK__pc_t_Apex__Purpo__09BF4B92");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.PcTApexHistories)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("FK__pc_t_ApexH__Type__0AB36FCB");
            });

            modelBuilder.Entity<PcTApexRequest>(entity =>
            {
                entity.ToTable("pc_t_ApexRequest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApexId).HasColumnName("ApexID");

                entity.Property(e => e.DeletedBy).HasMaxLength(255);

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.RequestName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RequestStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.PcTApexRequests)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__pc_t_Apex__Reque__0BA79404");
            });

            modelBuilder.Entity<PcTApexStatusTransactionAttachment>(entity =>
            {
                entity.HasKey(e => e.AttachmentId)
                    .HasName("PK__pc_t_Ape__442C64BEF4C894E2");

                entity.ToTable("pc_t_ApexStatusTransactionAttachments");

                entity.Property(e => e.FileName).HasMaxLength(200);

                entity.Property(e => e.Size).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.UploadedBy).HasMaxLength(250);

                entity.Property(e => e.Url)
                    .HasMaxLength(400)
                    .HasColumnName("URL");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.PcTApexStatusTransactionAttachments)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK__pc_t_Apex__Trans__0C9BB83D");
            });

            modelBuilder.Entity<PcTApexSupportingDocument>(entity =>
            {
                entity.ToTable("pc_t_ApexSupportingDocuments");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApexId).HasColumnName("ApexID");

                entity.Property(e => e.ShariaRepoId).HasColumnName("ShariaRepoID");

                //entity.HasOne(d => d.Apex)
                //    .WithMany(p => p.PcTApexSupportingDocuments)
                //    .HasForeignKey(d => d.ApexId)
                //    .HasConstraintName("FK__pc_t_Apex__ApexI__0D8FDC76");

                entity.HasOne(d => d.DocumentTypeNavigation)
                    .WithMany(p => p.PcTApexSupportingDocuments)
                    .HasForeignKey(d => d.DocumentType)
                    .HasConstraintName("FK_pc_t_ApexSupportingDocuments_sr_m_DocumentType");

                //entity.HasOne(d => d.ShariaRepo)
                //    .WithMany(p => p.PcTApexSupportingDocuments)
                //    .HasForeignKey(d => d.ShariaRepoId)
                //    .HasConstraintName("FK__pc_t_Apex__Shari__0E8400AF");
            });

            modelBuilder.Entity<PcTApexTransaction>(entity =>
            {
                entity.ToTable("pc_t_ApexTransactions");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Action).HasMaxLength(100);

                entity.Property(e => e.ApexId).HasColumnName("ApexID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);
                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.FromPersonId)
                 .HasMaxLength(324)
                 .HasColumnName("FromPersonID");

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.ToPersonId)
                    .HasMaxLength(324)
                    .HasColumnName("ToPersonID");

                entity.Property(e => e.TransactionBy).HasMaxLength(500);

                entity.Property(e => e.TransactionByDisplayName)
                    .HasMaxLength(300)
                    .HasColumnName("TransactionBy_DisplayName");

                entity.Property(e => e.TransactionByRole)
                    .HasMaxLength(300)
                    .HasColumnName("TransactionBy_Role");


            });

            modelBuilder.Entity<PcTRequestAlUsoolDocumentsLink>(entity =>
            {
                entity.ToTable("pc_t_RequestAlUsoolDocumentsLink");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DocumentName).HasMaxLength(200);

                entity.Property(e => e.DocumentType).HasMaxLength(200);

                entity.Property(e => e.ObjectId)
                    .HasMaxLength(200)
                    .HasColumnName("objectId");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.SearchBy).HasMaxLength(200);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.PcTRequestAlUsoolDocumentsLinks)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__pc_t_Requ__Reque__4B8221F7");
            });

            modelBuilder.Entity<PcTRequestApex>(entity =>
            {
                entity.ToTable("pc_t_RequestApex");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.Apex)
                    .WithMany(p => p.PcTRequestApices)
                    .HasForeignKey(d => d.ApexId)
                    .HasConstraintName("FK__pc_t_Requ__ApexI__2902ECC1");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.PcTRequestApices)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__pc_t_Requ__Reque__280EC888");
            });

            modelBuilder.Entity<PcTRequestExtendedField>(entity =>
            {
                entity.ToTable("pc_t_RequestExtendedFields");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LegalAssignedTo).HasMaxLength(500);

                entity.Property(e => e.LegalStatus).HasMaxLength(100);

                entity.Property(e => e.ModifyTawazunId).HasColumnName("ModifyTawazunID");

                entity.Property(e => e.ProductApprovalId).HasColumnName("ProductApprovalID");

                entity.Property(e => e.ProductConceptApprovalId).HasColumnName("ProductConceptApprovalID");

                entity.Property(e => e.ProductConceptName).HasMaxLength(200);

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.HasOne(d => d.BusinessUnitNavigation)
                    .WithMany(p => p.PcTRequestExtendedFields)
                    .HasForeignKey(d => d.BusinessUnit)
                    .HasConstraintName("FK__pc_t_Requ__Busin__4C764630");

                entity.HasOne(d => d.DivisionNavigation)
                    .WithMany(p => p.PcTRequestExtendedFields)
                    .HasForeignKey(d => d.Division)
                    .HasConstraintName("FK__pc_t_Requ__Divis__4D6A6A69");

                entity.HasOne(d => d.OrganizationNavigation)
                    .WithMany(p => p.PcTRequestExtendedFields)
                    .HasForeignKey(d => d.Organization)
                    .HasConstraintName("FK__pc_t_Requ__Organ__4E5E8EA2");

                entity.HasOne(d => d.PruposeNavigation)
                    .WithMany(p => p.PcTRequestExtendedFields)
                    .HasForeignKey(d => d.Prupose)
                    .HasConstraintName("FK__pc_t_Requ__Prupo__4F52B2DB");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.PcTRequestExtendedFields)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__pc_t_Requ__Reque__5046D714");

                entity.HasOne(d => d.SegmentNavigation)
                    .WithMany(p => p.PcTRequestExtendedFields)
                    .HasForeignKey(d => d.Segment)
                    .HasConstraintName("FK__pc_t_Requ__Segme__4A23E96A");

                entity.HasOne(d => d.ShariaModeNavigation)
                    .WithMany(p => p.PcTRequestExtendedFields)
                    .HasForeignKey(d => d.ShariaMode)
                    .HasConstraintName("FK__pc_t_Requ__Shari__513AFB4D");

                entity.HasOne(d => d.SubjectInstrumentNavigation)
                    .WithMany(p => p.PcTRequestExtendedFields)
                    .HasForeignKey(d => d.SubjectInstrument)
                    .HasConstraintName("FK__pc_t_Requ__Subje__522F1F86");

                entity.HasOne(d => d.TypesNavigation)
                    .WithMany(p => p.PcTRequestExtendedFields)
                    .HasForeignKey(d => d.Types)
                    .HasConstraintName("FK__pc_t_Requ__Types__532343BF");
            });

            modelBuilder.Entity<PcTRequestVarient>(entity =>
            {
                entity.ToTable("pc_t_RequestVarient");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.PcTRequestVarients)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__pc_t_Requ__Reque__0FC23DAB");
            });

            modelBuilder.Entity<PcTTawazun>(entity =>
            {
                entity.ToTable("pc_t_Tawazun");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Approver).HasMaxLength(500);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.CustomTawazunId)
                    .HasMaxLength(500)
                    .HasColumnName("CustomTawazunID");

                entity.Property(e => e.DepartmentName).HasMaxLength(500);

                entity.Property(e => e.EmployeeId).HasMaxLength(300);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.OtherTawazunIds).HasMaxLength(500);

                entity.Property(e => e.ProductApprovalId).HasColumnName("ProductApprovalID");

                entity.Property(e => e.ProductConceptApprovalId).HasColumnName("ProductConceptApprovalID");

                entity.Property(e => e.ProductVarient).HasMaxLength(200);

                entity.Property(e => e.ShariasMode).HasMaxLength(500);

                entity.Property(e => e.Status).HasMaxLength(400);

                entity.Property(e => e.TawazunCountryGroups).HasColumnName("Tawazun_country_groups");

                entity.HasOne(d => d.PurposeNavigation)
                    .WithMany(p => p.PcTTawazuns)
                    .HasForeignKey(d => d.Purpose)
                    .HasConstraintName("FK__pc_t_Tawa__Purpo__5DABBF2A");

                entity.HasOne(d => d.SegmentNavigation)
                    .WithMany(p => p.PcTTawazuns)
                    .HasForeignKey(d => d.Segment)
                    .HasConstraintName("FK__pc_t_Tawa__Segme__40DA7652");

                entity.HasOne(d => d.SubSidiaryNavigation)
                    .WithMany(p => p.PcTTawazuns)
                    .HasForeignKey(d => d.SubSidiary)
                    .HasConstraintName("FK__pc_t_Tawa__SubSi__5CB79AF1");

                entity.HasOne(d => d.SubsegmentNavigation)
                    .WithMany(p => p.PcTTawazuns)
                    .HasForeignKey(d => d.Subsegment)
                    .HasConstraintName("FK__pc_t_Tawa__Subse__41CE9A8B");

                entity.HasOne(d => d.TawazunTypeNavigation)
                    .WithMany(p => p.PcTTawazuns)
                    .HasForeignKey(d => d.TawazunType)
                    .HasConstraintName("FK__pc_t_Tawa__Tawaz__5E9FE363");
            });

            modelBuilder.Entity<PcTTawazunCommentsAttachment>(entity =>
            {
                entity.ToTable("pc_t_TawazunCommentsAttachment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttachmentUrl).HasMaxLength(500);

                entity.Property(e => e.FileName).HasMaxLength(200);

                entity.Property(e => e.FilePath).HasMaxLength(300);

                entity.Property(e => e.FileSize).HasMaxLength(200);

                entity.Property(e => e.UploadedBy).HasMaxLength(500);

                entity.HasOne(d => d.Tawazun)
                    .WithMany(p => p.PcTTawazunCommentsAttachments)
                    .HasForeignKey(d => d.TawazunId)
                    .HasConstraintName("FK__pc_t_Tawa__Tawaz__5F94079C");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.PcTTawazunCommentsAttachments)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK__pc_t_Tawa__Trans__60882BD5");
            });

            modelBuilder.Entity<PcTTawazunCountryGroup>(entity =>
            {
                entity.HasKey(e => e.Groupid)
                    .HasName("PK__pc_t_Taw__88C40F85B45C740A");

                entity.ToTable("pc_t_Tawazun_country_groups");

                entity.Property(e => e.Groupid).HasColumnName("groupid");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Groupname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("groupname");
            });

            modelBuilder.Entity<PcTTawazunHistory>(entity =>
            {
                entity.ToTable("pc_t_TawazunHistory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Approver).HasMaxLength(500);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.CustomTawazunId).HasMaxLength(200);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.ProductConceptId).HasColumnName("ProductConceptID");

                entity.Property(e => e.ProductCreationId).HasColumnName("ProductCreationID");

                entity.Property(e => e.ProductVarient).HasMaxLength(200);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.TawazunId).HasColumnName("TawazunID");

                entity.Property(e => e.TawazunCountryGroups).HasColumnName("Tawazun_country_groups");

                entity.HasOne(d => d.Tawazun)
                    .WithMany(p => p.PcTTawazunHistories)
                    .HasForeignKey(d => d.TawazunId)
                    .HasConstraintName("FK__pc_t_Tawa__Tawaz__617C500E");
            });

            modelBuilder.Entity<PcTTawazunPackageAttachment>(entity =>
            {
                entity.ToTable("pc_t_TawazunPackageAttachments");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttachmentUrl).HasMaxLength(500);

                entity.Property(e => e.FileName).HasMaxLength(200);

                entity.Property(e => e.FilePath).HasMaxLength(200);

                entity.Property(e => e.FileSize).HasMaxLength(200);

                entity.Property(e => e.TransactionBy).HasMaxLength(500);

                entity.HasOne(d => d.PackageTawazun)
                    .WithMany(p => p.PcTTawazunPackageAttachments)
                    .HasForeignKey(d => d.PackageTawazunId)
                    .HasConstraintName("FK__pc_t_Tawa__Packa__62707447");
            });

            modelBuilder.Entity<PcTTawazunPackageParent>(entity =>
            {
                entity.ToTable("pc_t_TawazunPackageParent");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(500)
                    .HasColumnName("createdBy");

                entity.Property(e => e.ParentTawazunName).HasMaxLength(200);

                entity.HasOne(d => d.PackageTawazun)
                    .WithMany(p => p.PcTTawazunPackageParentPackageTawazuns)
                    .HasForeignKey(d => d.PackageTawazunId)
                    .HasConstraintName("FK__pc_t_Tawa__Packa__63649880");

                entity.HasOne(d => d.ParentTawaun)
                    .WithMany(p => p.PcTTawazunPackageParentParentTawauns)
                    .HasForeignKey(d => d.ParentTawaunId)
                    .HasConstraintName("FK__pc_t_Tawa__Paren__6458BCB9");
            });

            modelBuilder.Entity<PcTTawazunPackageVarient>(entity =>
            {
                entity.ToTable("pc_t_TawazunPackageVarient");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(500)
                    .HasColumnName("createdBy");

                entity.Property(e => e.ParentVarientTawazunName).HasMaxLength(200);

                entity.HasOne(d => d.PackageTawazun)
                    .WithMany(p => p.PcTTawazunPackageVarients)
                    .HasForeignKey(d => d.PackageTawazunId)
                    .HasConstraintName("FK__pc_t_Tawa__Packa__654CE0F2");

                entity.HasOne(d => d.ProductVarientTawaun)
                    .WithMany(p => p.PcTTawazunPackageVarients)
                    .HasForeignKey(d => d.ProductVarientTawaunId)
                    .HasConstraintName("FK__pc_t_Tawa__Produ__6641052B");
            });

            modelBuilder.Entity<PcTTawazunTransaction>(entity =>
            {
                entity.ToTable("pc_t_TawazunTransaction");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Action).HasMaxLength(50);

                entity.Property(e => e.CheckerDraftStatus).HasMaxLength(200);

                entity.Property(e => e.FromPersonId)
                    .HasMaxLength(324)
                    .HasColumnName("FromPersonID");

                entity.Property(e => e.TawazunId).HasColumnName("TawazunID");

                entity.Property(e => e.ToPersonId)
                    .HasMaxLength(324)
                    .HasColumnName("ToPersonID");

                entity.Property(e => e.TransactionBy).HasMaxLength(500);

                entity.Property(e => e.TransactionByDisplayName)
                    .HasMaxLength(300)
                    .HasColumnName("TransactionBy_DisplayName");

                entity.Property(e => e.TransactionByRole)
                    .HasMaxLength(300)
                    .HasColumnName("TransactionBy_Role");

                entity.HasOne(d => d.Tawazun)
                  .WithMany(p => p.PcTTawazunTransactions)
                  .HasForeignKey(d => d.TawazunId)
                  .HasConstraintName("FK__pc_t_Tawa__Tawaz__30242045");
            });


            modelBuilder.Entity<PcTTawazunVarient>(entity =>
            {
                entity.ToTable("pc_t_TawazunVarient");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompliedBy).HasMaxLength(500);

                entity.Property(e => e.CompliedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.CustomVarientId).HasMaxLength(100);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.TawazunFkid).HasColumnName("TawazunFKID");

                entity.Property(e => e.TawazunId)
                    .HasMaxLength(500)
                    .HasColumnName("TawazunID");

                entity.Property(e => e.VarientId)
                    .HasMaxLength(500)
                    .HasColumnName("VarientID");

                entity.HasOne(d => d.SegmentNavigation)
                    .WithMany(p => p.PcTTawazunVarients)
                    .HasForeignKey(d => d.Segment)
                    .HasConstraintName("FK__pc_t_Tawa__Segme__43F60EC8");

                entity.HasOne(d => d.SubSegmentNavigation)
                    .WithMany(p => p.PcTTawazunVarients)
                    .HasForeignKey(d => d.SubSegment)
                    .HasConstraintName("FK__pc_t_Tawa__Categ__44EA3301");

                entity.HasOne(d => d.TawazunFk)
                    .WithMany(p => p.PcTTawazunVarients)
                    .HasForeignKey(d => d.TawazunFkid)
                    .HasConstraintName("FK__pc_t_Tawa__Tawaz__7993056A");
            });

            modelBuilder.Entity<PcTTawazunVarientAlUsoolDocument>(entity =>
            {
                entity.ToTable("pc_t_TawazunVarientAlUsoolDocument");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DocumentName).HasMaxLength(200);

                entity.Property(e => e.DocumentType).HasMaxLength(200);

                entity.Property(e => e.ObjectId).HasMaxLength(200);

                entity.Property(e => e.SearchBy).HasMaxLength(500);

                entity.Property(e => e.TawazunId).HasColumnName("TawazunID");

                entity.Property(e => e.VarientId).HasColumnName("VarientID");

                entity.HasOne(d => d.Tawazun)
                    .WithMany(p => p.PcTTawazunVarientAlUsoolDocuments)
                    .HasForeignKey(d => d.TawazunId)
                    .HasConstraintName("FK__pc_t_Tawa__Tawaz__6B05BA48");
            });

            modelBuilder.Entity<PcTTawazunVarientApex>(entity =>
            {
                entity.ToTable("pc_t_TawazunVarientApex");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApexId).HasColumnName("ApexID");

                entity.Property(e => e.TawazunId).HasColumnName("TawazunID");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.VarientId).HasColumnName("VarientID");

                entity.HasOne(d => d.Apex)
                    .WithMany(p => p.PcTTawazunVarientApices)
                    .HasForeignKey(d => d.ApexId)
                    .HasConstraintName("FK__pc_t_Tawa__ApexI__6BF9DE81");

                entity.HasOne(d => d.Tawazun)
                    .WithMany(p => p.PcTTawazunVarientApices)
                    .HasForeignKey(d => d.TawazunId)
                    .HasConstraintName("FK__pc_t_Tawa__Tawaz__6CEE02BA");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.PcTTawazunVarientApices)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK__pc_t_Tawa__Trans__6DE226F3");
            });

            modelBuilder.Entity<PcTTawazunVarientAttachment>(entity =>
            {
                entity.ToTable("pc_t_TawazunVarientAttachments");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DocumentSize).HasMaxLength(100);

                entity.Property(e => e.DocumentUri)
                    .HasMaxLength(500)
                    .HasColumnName("DocumentURI");

                entity.Property(e => e.FileName).HasMaxLength(200);

                entity.Property(e => e.FilePath).HasMaxLength(500);

                entity.Property(e => e.TawazunId).HasColumnName("TawazunID");

                entity.Property(e => e.UploadedBy).HasMaxLength(500);

                entity.Property(e => e.VarientId).HasColumnName("VarientID");

                entity.HasOne(d => d.Tawazun)
                    .WithMany(p => p.PcTTawazunVarientAttachments)
                    .HasForeignKey(d => d.TawazunId)
                    .HasConstraintName("FK__pc_t_Tawa__Tawaz__6ED64B2C");
            });

            modelBuilder.Entity<PcTTawazunVarientComplyAttachment>(entity =>
            {
                entity.ToTable("pc_t_TawazunVarientComplyAttachments");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttachmentUrl)
                    .HasMaxLength(500)
                    .HasColumnName("AttachmentURL");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(255);

                entity.Property(e => e.FileName).HasMaxLength(200);

                entity.Property(e => e.Size).HasMaxLength(100);

                entity.Property(e => e.TawazunVarientCustomId).HasColumnName("TawazunVarientCustomID");

                entity.Property(e => e.TawazunVarientId).HasColumnName("TawazunVarientID");
            });


            modelBuilder.Entity<PcTTawazunVarientHistory>(entity =>
            {
                entity.ToTable("pc_t_TawazunVarientHistory");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.CustomVarientId).HasMaxLength(200);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .HasMaxLength(300)
                    .HasColumnName("name");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status");

                entity.HasOne(d => d.Tawazun)
                    .WithMany(p => p.PcTTawazunVarientHistories)
                    .HasForeignKey(d => d.TawazunId)
                    .HasConstraintName("FK__pc_t_Tawa__Tawaz__6FCA6F65");

                entity.HasOne(d => d.Varient)
                    .WithMany(p => p.PcTTawazunVarientHistories)
                    .HasForeignKey(d => d.VarientId)
                    .HasConstraintName("FK__pc_t_Tawa__Varie__70BE939E");
            });

            modelBuilder.Entity<ReportsTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Reports_Table");

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SNo)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("s_no");

                entity.Property(e => e.SchemaName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Schema_Name");

                entity.Property(e => e.TableName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Table_Name");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.CreatedBy).HasMaxLength(507);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK__Roles__Applicati__5AC46587");
            });

            modelBuilder.Entity<Rolehistory>(entity =>
            {
                entity.ToTable("Rolehistory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Rolehistories)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Rolehisto__RoleI__3B16B004");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Rolehistories)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Rolehisto__UserI__3A228BCB");
            });

            modelBuilder.Entity<SkrMNoteType>(entity =>
            {
                entity.ToTable("skr_m_NoteType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);
            });

            modelBuilder.Entity<SkrMReseachType>(entity =>
            {
                entity.ToTable("skr_m_ReseachType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);
            });

            modelBuilder.Entity<SkrTAttachment>(entity =>
            {
                entity.HasKey(e => e.AttachmentId)
                    .HasName("PK__skr_t_At__442C64DEC2DB5782");

                entity.ToTable("skr_t_Attachments");

                entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.NoteId).HasColumnName("NoteID");

                entity.Property(e => e.ResearchId).HasColumnName("ResearchID");

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .HasColumnName("URL");

                entity.HasOne(d => d.Note)
                    .WithMany(p => p.SkrTAttachments)
                    .HasForeignKey(d => d.NoteId)
                    .HasConstraintName("FK__skr_t_Att__NoteI__62307D25");

                entity.HasOne(d => d.Research)
                    .WithMany(p => p.SkrTAttachments)
                    .HasForeignKey(d => d.ResearchId)
                    .HasConstraintName("FK__skr_t_Att__Resea__5BB889C0");
            });

            modelBuilder.Entity<SkrTNote>(entity =>
            {
                entity.HasKey(e => e.NoteId)
                    .HasName("PK__skr_t_No__EACE357FF8470026");

                entity.ToTable("skr_t_Notes");

                entity.Property(e => e.NoteId).HasColumnName("NoteID");

                entity.Property(e => e.CreatedBy).HasMaxLength(507);

                entity.Property(e => e.ModifiedBy).HasMaxLength(507);

                entity.Property(e => e.ResearchId).HasColumnName("ResearchID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Research)
                    .WithMany(p => p.SkrTNotes)
                    .HasForeignKey(d => d.ResearchId)
                    .HasConstraintName("FK__skr_t_Not__Resea__5CACADF9");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.SkrTNotes)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("FK__skr_t_Note__Type__5DA0D232");
            });

            modelBuilder.Entity<SkrTNoteTypeLog>(entity =>
            {
                entity.ToTable("skr_t_NoteTypeLogs");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.HasOne(d => d.NoteType)
                    .WithMany(p => p.SkrTNoteTypeLogs)
                    .HasForeignKey(d => d.NoteTypeId)
                    .HasConstraintName("FK__skr_t_Not__NoteT__6DA22FD1");
            });

            modelBuilder.Entity<SkrTNotesHistory>(entity =>
            {
                entity.HasKey(e => e.HistoryId)
                    .HasName("PK__skr_t_No__4D7B4ADD374C332C");

                entity.ToTable("skr_t_NotesHistory");

                entity.Property(e => e.HistoryId).HasColumnName("HistoryID");

                entity.Property(e => e.CreatedBy).HasMaxLength(507);

                entity.Property(e => e.ModifiedBy).HasMaxLength(507);

                entity.Property(e => e.NoteId).HasColumnName("NoteID");

                entity.Property(e => e.ResearchId).HasColumnName("ResearchID");

                entity.HasOne(d => d.NoteNavigation)
                    .WithMany(p => p.SkrTNotesHistories)
                    .HasForeignKey(d => d.NoteId)
                    .HasConstraintName("FK__skr_t_Not__NoteI__5E94F66B");

                entity.HasOne(d => d.Research)
                    .WithMany(p => p.SkrTNotesHistories)
                    .HasForeignKey(d => d.ResearchId)
                    .HasConstraintName("FK__skr_t_Not__Resea__5F891AA4");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.SkrTNotesHistories)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("FK__skr_t_Note__Type__607D3EDD");
            });

            modelBuilder.Entity<SkrTPeer>(entity =>
            {
                entity.ToTable("skr_t_Peers");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PeerEmailId).HasColumnName("PeerEmailID");

                entity.Property(e => e.ResearchId).HasColumnName("ResearchID");

                entity.HasOne(d => d.Research)
                    .WithMany(p => p.SkrTPeers)
                    .HasForeignKey(d => d.ResearchId)
                    .HasConstraintName("FK__skr_t_Pee__Resea__61716316");
            });

            modelBuilder.Entity<SkrTResearchBook>(entity =>
            {
                entity.HasKey(e => e.ResearchId)
                    .HasName("PK__skr_t_Re__617A95AE5FD757D8");

                entity.ToTable("skr_t_ResearchBook");

                entity.Property(e => e.ResearchId).HasColumnName("ResearchID");

                entity.Property(e => e.Branch).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(507);

                entity.Property(e => e.CustomResearchId).HasMaxLength(207);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.HasOne(d => d.ResearchTypeNavigation)
                    .WithMany(p => p.SkrTResearchBooks)
                    .HasForeignKey(d => d.ResearchType)
                    .HasConstraintName("FK__skr_t_Res__Resea__2764BD12");
            });

            modelBuilder.Entity<SkrTResearchBookTicketMapping>(entity =>
            {
                entity.ToTable("skr_t_ResearchBookTicketMapping");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ResearchId).HasColumnName("ResearchID");

                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.HasOne(d => d.Research)
                    .WithMany(p => p.SkrTResearchBookTicketMappings)
                    .HasForeignKey(d => d.ResearchId)
                    .HasConstraintName("FK__skr_t_Res__Resea__644DCFC1");
            });

            modelBuilder.Entity<SkrTResearchTypeLog>(entity =>
            {
                entity.ToTable("skr_t_ResearchTypeLogs");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.HasOne(d => d.ResearchType)
                    .WithMany(p => p.SkrTResearchTypeLogs)
                    .HasForeignKey(d => d.ResearchTypeId)
                    .HasConstraintName("FK__skr_t_Res__Resea__6AC5C326");
            });

            modelBuilder.Entity<SrMCountry>(entity =>
            {
                entity.ToTable("sr_m_Country");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArabicTitle).HasMaxLength(255);

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<SrMDocumentType>(entity =>
            {
                entity.ToTable("sr_m_DocumentType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArabicTitle).HasMaxLength(255);

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<SrMLanguage>(entity =>
            {
                entity.ToTable("sr_m_Language");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArabicTitle).HasMaxLength(255);

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<SrMRegulatory>(entity =>
            {
                entity.ToTable("sr_m_Regulatory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArabicTitle).HasMaxLength(255);

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<SrMShariaModule>(entity =>
            {
                entity.ToTable("sr_m_ShariaModule");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArabicTitle).HasMaxLength(255);

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<SrMSubShariaModule>(entity =>
            {
                entity.ToTable("sr_m_SubShariaModule");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArabicTitle).HasMaxLength(255);

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(255);

                entity.Property(e => e.ShariaModuleId).HasColumnName("ShariaModuleID");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.ShariaModule)
                    .WithMany(p => p.SrMSubShariaModules)
                    .HasForeignKey(d => d.ShariaModuleId)
                    .HasConstraintName("FK__sr_m_SubS__Shari__6541F3FA");
            });

            modelBuilder.Entity<SrTBookMarkDocument>(entity =>
            {
                entity.ToTable("sr_t_BookMarkDocuments");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.SrTBookMarkDocuments)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sr_t_Book__Docum__66361833");
            });

            modelBuilder.Entity<SrTDocumentComment>(entity =>
            {
                entity.ToTable("sr_t_DocumentComments");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CommentBy).HasMaxLength(255);

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.ReferMessageId).HasColumnName("ReferMessageID");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.SrTDocumentComments)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sr_t_Docu__Docum__672A3C6C");

                entity.HasOne(d => d.ReferMessage)
                    .WithMany(p => p.InverseReferMessage)
                    .HasForeignKey(d => d.ReferMessageId)
                    .HasConstraintName("FK__sr_t_Docu__Refer__681E60A5");
            });

            modelBuilder.Entity<SrTDocumentShare>(entity =>
            {
                entity.ToTable("sr_t_DocumentShare");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccessLevel).HasMaxLength(255);

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.SharedBy).HasMaxLength(255);

                entity.Property(e => e.SharedTo).HasMaxLength(255);
            });

            modelBuilder.Entity<SrTDocumentView>(entity =>
            {
                entity.ToTable("sr_t_DocumentViews");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.UserEmail).HasMaxLength(255);

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.SrTDocumentViews)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sr_t_Docu__Docum__6A06A917");
            });

            modelBuilder.Entity<SrTLinkedDocument>(entity =>
            {
                entity.ToTable("sr_t_LinkedDocuments");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.ReferDocumentId).HasColumnName("ReferDocumentID");

                entity.HasOne(d => d.ReferDocument)
                    .WithMany(p => p.SrTLinkedDocuments)
                    .HasForeignKey(d => d.ReferDocumentId)
                    .HasConstraintName("FK__sr_t_Link__Refer__6AFACD50");
            });

            modelBuilder.Entity<SrTShariaDocument>(entity =>
            {
                entity.HasKey(e => e.DocumentId)
                    .HasName("PK__sr_t_Sha__1ABEEF6F9CCBD0B1");

                entity.ToTable("sr_t_ShariaDocuments");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.ApprovalAttachmentsUrl).HasMaxLength(450);

                entity.Property(e => e.ApprovedBy).HasMaxLength(255);

                entity.Property(e => e.DateOfNotificationOfResolution).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(255);

                entity.Property(e => e.Departments).HasMaxLength(255);

                entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

                entity.Property(e => e.FileUrl).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(255);

                entity.Property(e => e.RecipientCC)
                     .HasMaxLength(500)
                     .HasColumnName("RecipientCC");

                entity.Property(e => e.RecipientTo).HasMaxLength(500);

                entity.Property(e => e.ResolutionNo).HasMaxLength(50);

                entity.Property(e => e.SerialNumber).HasMaxLength(50);

                entity.Property(e => e.ShariaModuleId).HasColumnName("ShariaModuleID");

                entity.Property(e => e.SubShariaModuleId).HasColumnName("SubShariaModuleID");

                entity.Property(e => e.ThumbnailUrl).HasMaxLength(450);

                entity.Property(e => e.TitleArabic).HasMaxLength(255);

                entity.Property(e => e.TitleEnglish).HasMaxLength(255);

                entity.Property(e => e.UniqueFolderName).HasMaxLength(255);

                entity.Property(e => e.UploadedBy).HasMaxLength(255);

                entity.Property(e => e.YearlySerialNumber).HasMaxLength(50);

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.SrTShariaDocuments)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("FK__sr_t_Shar__Count__7889D298");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.SrTShariaDocuments)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .HasConstraintName("FK__sr_t_Shar__Docum__797DF6D1");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.SrTShariaDocuments)
                    .HasForeignKey(d => d.Language)
                    .HasConstraintName("FK__sr_t_Shar__Langu__7A721B0A");

                entity.HasOne(d => d.RegulatoryNavigation)
                    .WithMany(p => p.SrTShariaDocuments)
                    .HasForeignKey(d => d.Regulatory)
                    .HasConstraintName("FK__sr_t_Shar__Regul__7B663F43");
            });

            modelBuilder.Entity<SrTShariaDocumentHistory>(entity =>
            {
                entity.HasKey(e => e.HistoryId)
                    .HasName("PK__sr_t_Sha__4D7B4ADDF24987A9");

                entity.ToTable("sr_t_ShariaDocumentHistory");

                entity.Property(e => e.HistoryId).HasColumnName("HistoryID");

                entity.Property(e => e.ApprovalAttachmentsUrl).HasMaxLength(450);

                entity.Property(e => e.ApprovedBy).HasMaxLength(255);

                entity.Property(e => e.ArabicKeywords).HasMaxLength(450);

                entity.Property(e => e.DateOfNotificationOfResolution).HasColumnType("datetime");

                entity.Property(e => e.Departments).HasMaxLength(255);

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

                entity.Property(e => e.EnglishKeywords).HasMaxLength(450);

                entity.Property(e => e.FileUrl).HasMaxLength(450);

                entity.Property(e => e.ModifiedBy).HasMaxLength(255);

                entity.Property(e => e.RecipientCC)
                    .HasMaxLength(500)
                    .HasColumnName("RecipientCC");

                entity.Property(e => e.RecipientTo).HasMaxLength(500);

                entity.Property(e => e.ResolutionNo).HasMaxLength(50);

                entity.Property(e => e.SerialNumber).HasMaxLength(50);

                entity.Property(e => e.ShariaModuleId).HasColumnName("ShariaModuleID");

                entity.Property(e => e.SubShariaModuleId).HasColumnName("SubShariaModuleID");

                entity.Property(e => e.ThumbnailUrl).HasMaxLength(450);

                entity.Property(e => e.TitleArabic).HasMaxLength(255);

                entity.Property(e => e.TitleEnglish).HasMaxLength(255);

                entity.Property(e => e.UnderlyingContracts).HasMaxLength(255);

                entity.Property(e => e.UploadedBy).HasMaxLength(255);

                entity.Property(e => e.YearlySerialNumber).HasMaxLength(50);

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.SrTShariaDocumentHistories)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("FK__sr_t_Shar__Count__71DCD509");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.SrTShariaDocumentHistories)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sr_t_Shar__Docum__73C51D7B");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.SrTShariaDocumentHistories)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .HasConstraintName("FK__sr_t_Shar__Docum__72D0F942");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.SrTShariaDocumentHistories)
                    .HasForeignKey(d => d.Language)
                    .HasConstraintName("FK__sr_t_Shar__Langu__74B941B4");

                entity.HasOne(d => d.RegulatoryNavigation)
                    .WithMany(p => p.SrTShariaDocumentHistories)
                    .HasForeignKey(d => d.Regulatory)
                    .HasConstraintName("FK__sr_t_Shar__Regul__75AD65ED");
            });

            modelBuilder.Entity<StandardMessageMaster>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Standard__3214EC27C03DDE6A");

                entity.ToTable("StandardMessageMaster");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Message).HasMaxLength(2000);
                entity.Property(e => e.ModuleName).HasMaxLength(200);
                entity.Property(e => e.StatusCondition).HasMaxLength(200);
                entity.Property(e => e.SubModuleName).HasMaxLength(200);
            });

            modelBuilder.Entity<UscAlUsool>(entity =>
            {
                entity.ToTable("usc_al-usool");

                entity.Property(e => e.ObjectId)
                    .HasMaxLength(255)
                    .HasColumnName("ObjectID");

                entity.Property(e => e.ReferenceNumber).HasMaxLength(255);
            });

            modelBuilder.Entity<UscMCharge>(entity =>
            {
                entity.ToTable("usc_m_Charges");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<UscMCriterion>(entity =>
            {
                entity.ToTable("usc_m_Criteria");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<UscMLoyalty>(entity =>
            {
                entity.ToTable("usc_m_Loyalty");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<UscMQuestion>(entity =>
            {
                entity.HasKey(e => e.QuestionId)
                    .HasName("PK__usc_m_Qu__0DC06F8C34A6DDEE");

                entity.ToTable("usc_m_Questions");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.CreatedBy).HasMaxLength(324);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.IsMandatory).HasColumnName("isMandatory");

                entity.Property(e => e.ModifiedBy).HasMaxLength(324);

                entity.Property(e => e.SubProductId).HasColumnName("SubProductID");

                entity.HasOne(d => d.SubProduct)
                    .WithMany(p => p.UscMQuestions)
                    .HasForeignKey(d => d.SubProductId)
                    .HasConstraintName("FK__usc_m_Que__SubPr__459F2B6F");
            });

            modelBuilder.Entity<UscMRate>(entity =>
            {
                entity.ToTable("usc_m_Rate");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<UscMStatus>(entity =>
            {
                entity.ToTable("usc_M_Status");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.RoleBy).HasMaxLength(200);

                entity.Property(e => e.StatusName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UscTCommentsVertexTransactionAttachment>(entity =>
            {
                entity.ToTable("usc_t_CommentsVertexTransactionAttachment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.FileName).HasMaxLength(500);

                entity.Property(e => e.FilePath).HasMaxLength(500);

                entity.Property(e => e.FileSize).HasMaxLength(200);

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.UscTCommentsVertexTransactionAttachments)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK__usc_t_Com__Trans__71B2B7D7");

                entity.HasOne(d => d.Vertex)
                    .WithMany(p => p.UscTCommentsVertexTransactionAttachments)
                    .HasForeignKey(d => d.VertexId)
                    .HasConstraintName("FK__usc_t_Com__Verte__72A6DC10");
            });

            modelBuilder.Entity<UscTFavouriteVertex>(entity =>
            {
                entity.ToTable("usc_t_FavouriteVertex");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.VertexId).HasColumnName("VertexID");

                entity.HasOne(d => d.Vertex)
                    .WithMany(p => p.UscTFavouriteVertices)
                    .HasForeignKey(d => d.VertexId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usc_t_Fav__Verte__739B0049");
            });

            modelBuilder.Entity<UscTOffer>(entity =>
            {
                entity.HasKey(e => e.OfferId);

                entity.ToTable("usc_t_Offers");

                entity.Property(e => e.OfferId).HasColumnName("OfferID");

                entity.Property(e => e.BranchName).HasMaxLength(207);

                entity.Property(e => e.CreatedBy).HasMaxLength(207);

                entity.Property(e => e.CustumOfferId).HasMaxLength(200);

                entity.Property(e => e.DescriptionWithoutHtml).HasColumnName("Description_WithoutHTML");

                entity.Property(e => e.EmployeeName).HasMaxLength(200);

                entity.Property(e => e.OfferName).HasMaxLength(300);

                entity.Property(e => e.RequestTypeName).HasMaxLength(207);

                entity.Property(e => e.Status).HasMaxLength(200);

                entity.Property(e => e.ThumbNailFileName).HasMaxLength(500);

                entity.Property(e => e.ThumbNailFilePath).HasMaxLength(500);

                entity.Property(e => e.ThumbNailFileSize).HasMaxLength(200);

                entity.Property(e => e.VertexId).HasColumnName("VertexID");

                entity.HasOne(d => d.BranchNavigation)
                    .WithMany(p => p.UscTOffers)
                    .HasForeignKey(d => d.Branch)
                    .HasConstraintName("FK__usc_t_Off__Branc__4A6E022D");

                entity.HasOne(d => d.RequestTypeNavigation)
                    .WithMany(p => p.UscTOffers)
                    .HasForeignKey(d => d.RequestType)
                    .HasConstraintName("FK__usc_t_Off__Reque__4B622666");

                entity.HasOne(d => d.SegmentNavigation)
                    .WithMany(p => p.UscTOffers)
                    .HasForeignKey(d => d.Segment)
                    .HasConstraintName("FK__usc_t_Off__Segme__1E855E4E");

                entity.HasOne(d => d.SubSegmentNavigation)
                    .WithMany(p => p.UscTOffers)
                    .HasForeignKey(d => d.SubSegment)
                    .HasConstraintName("FK__usc_t_off_Cate");

                entity.HasOne(d => d.Vertex)
                    .WithMany(p => p.UscTOffers)
                    .HasForeignKey(d => d.VertexId)
                    .HasConstraintName("FK__usc_t_Off__Verte__4C564A9F");
            });

            modelBuilder.Entity<UscTOfferApproverAttachment>(entity =>
            {
                entity.ToTable("usc_t_OfferApproverAttachments");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttachmentPath).HasMaxLength(500);

                entity.Property(e => e.AttachmentSize).HasMaxLength(207);

                entity.Property(e => e.AttchmentTitle).HasMaxLength(207);

                entity.Property(e => e.CreatedBy).HasMaxLength(207);

                entity.Property(e => e.OfferId).HasColumnName("OfferID");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.UscTOfferApproverAttachments)
                    .HasForeignKey(d => d.OfferId)
                    .HasConstraintName("FK__usc_t_Off__Offer__748F2482");
            });

            modelBuilder.Entity<UscTOfferMakerAttachment>(entity =>
            {
                entity.ToTable("usc_t_OfferMakerAttachments");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttchmentTitle).HasMaxLength(207);

                entity.Property(e => e.CreatedBy).HasMaxLength(207);

                entity.Property(e => e.FileName).HasMaxLength(500);

                entity.Property(e => e.FilePath).HasMaxLength(500);

                entity.Property(e => e.FileSize).HasMaxLength(200);

                entity.Property(e => e.OfferId).HasColumnName("OfferID");
            });

            modelBuilder.Entity<UscTOfferSliderImage>(entity =>
            {
                entity.ToTable("usc_t_OfferSliderImages");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttachmentUrl)
                    .HasMaxLength(500)
                    .HasColumnName("AttachmentURL");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.FileName).HasMaxLength(500);

                entity.Property(e => e.FilePath).HasMaxLength(500);

                entity.Property(e => e.FileSize).HasMaxLength(200);

                entity.Property(e => e.OfferId).HasColumnName("OfferID");
            });

            modelBuilder.Entity<UscTOfferSupportingAttachment>(entity =>
            {
                entity.ToTable("usc_t_OfferSupportingAttachments");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttachmentPath).HasMaxLength(500);

                entity.Property(e => e.AttachmentSize).HasMaxLength(207);

                entity.Property(e => e.AttchmentTitle).HasMaxLength(207);

                entity.Property(e => e.CreatedBy).HasMaxLength(207);

                entity.Property(e => e.OfferId).HasColumnName("OfferID");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.UscTOfferSupportingAttachments)
                    .HasForeignKey(d => d.OfferId)
                    .HasConstraintName("FK__usc_t_Off__Offer__7C30464A");
            });

            modelBuilder.Entity<UscTOffersTransaction>(entity =>
            {
                entity.ToTable("usc_t_OffersTransactions");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttachmentUrl).HasColumnName("AttachmentURL");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.OfferId).HasColumnName("OfferID");

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.UscTOffersTransactions)
                    .HasForeignKey(d => d.OfferId)
                    .HasConstraintName("FK__usc_t_Off__Offer__7B3C2211");
            });

            modelBuilder.Entity<UscTOtherMediaAttachment>(entity =>
            {
                entity.ToTable("usc_t_OtherMediaAttachments");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttachmentUrl)
                    .HasMaxLength(500)
                    .HasColumnName("AttachmentURL");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.FileName).HasMaxLength(500);

                entity.Property(e => e.FilePath).HasMaxLength(500);

                entity.Property(e => e.FileSize).HasMaxLength(200);

                entity.Property(e => e.Tital)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VertexId).HasColumnName("VertexID");

                entity.HasOne(d => d.Vertex)
                    .WithMany(p => p.UscTOtherMediaAttachments)
                    .HasForeignKey(d => d.VertexId)
                    .HasConstraintName("FK__usc_t_Oth__Verte__7D246A83");
            });

            modelBuilder.Entity<UscTProductAttachment>(entity =>
            {
                entity.ToTable("usc_t_ProductAttachments");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttachmentUrl)
                    .HasMaxLength(500)
                    .HasColumnName("AttachmentURL");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.FileName).HasMaxLength(500);

                entity.Property(e => e.FilePath).HasMaxLength(500);

                entity.Property(e => e.FileSize).HasMaxLength(200);

                entity.Property(e => e.VertexId).HasColumnName("VertexID");

                entity.HasOne(d => d.Vertex)
                    .WithMany(p => p.UscTProductAttachments)
                    .HasForeignKey(d => d.VertexId)
                    .HasConstraintName("FK__usc_t_Pro__Verte__7E188EBC");
            });

            modelBuilder.Entity<UscTProductCart>(entity =>
            {
                entity.ToTable("usc_t_ProductCart");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserId).HasMaxLength(207);

                entity.HasOne(d => d.Vertex)
                    .WithMany(p => p.UscTProductCarts)
                    .HasForeignKey(d => d.VertexId)
                    .HasConstraintName("FK__usc_t_Pro__Verte__7F0CB2F5");
            });

            modelBuilder.Entity<UscTSharedLeafletVertex>(entity =>
            {
                entity.ToTable("usc_t_SharedLeafletVertex");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.ToEmail).HasMaxLength(500);

                entity.Property(e => e.ToName).HasMaxLength(200);

                entity.Property(e => e.VertexId).HasColumnName("VertexID");

                entity.HasOne(d => d.Vertex)
                    .WithMany(p => p.UscTSharedLeafletVertices)
                    .HasForeignKey(d => d.VertexId)
                    .HasConstraintName("FK__usc_t_Sha__Verte__0000D72E");
            });

            modelBuilder.Entity<UscTSliderImagesAttachment>(entity =>
            {
                entity.ToTable("usc_t_SliderImagesAttachments");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.FileName).HasMaxLength(500);

                entity.Property(e => e.FilePath).HasMaxLength(500);

                entity.Property(e => e.FileSize).HasMaxLength(200);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(500)
                    .HasColumnName("ImageURL");

                entity.Property(e => e.VertexId).HasColumnName("VertexID");

                entity.HasOne(d => d.Vertex)
                    .WithMany(p => p.UscTSliderImagesAttachments)
                    .HasForeignKey(d => d.VertexId)
                    .HasConstraintName("FK__usc_t_Sli__Verte__00F4FB67");
            });

            modelBuilder.Entity<UscTSupportingDocument>(entity =>
            {
                entity.ToTable("usc_t_SupportingDocuments");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttachmentUrl)
                    .HasMaxLength(500)
                    .HasColumnName("AttachmentURL");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.FileName).HasMaxLength(500);

                entity.Property(e => e.FilePath).HasMaxLength(500);

                entity.Property(e => e.FileSize).HasMaxLength(200);

                entity.Property(e => e.VertexId).HasColumnName("VertexID");

                entity.HasOne(d => d.Vertex)
                    .WithMany(p => p.UscTSupportingDocuments)
                    .HasForeignKey(d => d.VertexId)
                    .HasConstraintName("FK__usc_t_Sup__Verte__01E91FA0");
            });

            modelBuilder.Entity<UscTVertex>(entity =>
            {
                entity.HasKey(e => e.VertexId)
                    .HasName("PK__usc_t_Ve__9B0AD975278795BC");

                entity.ToTable("usc_t_Vertex");

                entity.Property(e => e.VertexId).HasColumnName("VertexID");

                entity.Property(e => e.AssignedTo).HasMaxLength(500);

                entity.Property(e => e.BranchName).HasMaxLength(200);

                entity.Property(e => e.ChargeArabicWithoutHtml).HasColumnName("ChargeArabic_WithoutHTML");

                entity.Property(e => e.ChargeEnglishWithoutHtml).HasColumnName("ChargeEnglish_WithoutHTML");

                entity.Property(e => e.CompliedBy).HasMaxLength(500);

                entity.Property(e => e.CompliedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.CriteriaArabicWithoutHtml).HasColumnName("CriteriaArabic_WithoutHTML");

                entity.Property(e => e.CriteriaEnglishWithoutHtml).HasColumnName("CriteriaEnglish_WithoutHTML");

                entity.Property(e => e.CustomVertexId)
                    .HasMaxLength(100)
                    .HasColumnName("CustomVertexID");

                entity.Property(e => e.DepartmentName).HasMaxLength(200);

                entity.Property(e => e.DescriptionWithoutHtml).HasColumnName("Description_WithoutHTML");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FileLength).HasMaxLength(500);

                entity.Property(e => e.KeyBenefitsArabicWithoutHtml).HasColumnName("KeyBenefitsArabic_WithoutHTML");

                entity.Property(e => e.KeyBenefitsEnglishWithoutHtml).HasColumnName("KeyBenefitsEnglish_WithoutHTML");

                entity.Property(e => e.LegalAssignedTo).HasMaxLength(500);

                entity.Property(e => e.LegalStatus).HasMaxLength(100);

                entity.Property(e => e.LoyalityArabicWithoutHtml).HasColumnName("LoyalityArabic_WithoutHTML");

                entity.Property(e => e.LoyalityEnglishWithoutHtml).HasColumnName("LoyalityEnglish_WithoutHTML");

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.OtherBenefitsArabicWithoutHtml).HasColumnName("OtherBenefitsArabic_WithoutHTML");

                entity.Property(e => e.OtherBenefitsEnglishWithoutHtml).HasColumnName("OtherBenefitsEnglish_WithoutHTML");

                entity.Property(e => e.PreviousVertexId).HasColumnName("PreviousVertexID");

                entity.Property(e => e.RateArabicWithoutHtml).HasColumnName("RateArabic_WithoutHTML");

                entity.Property(e => e.RateEnglishWithoutHtml).HasColumnName("RateEnglish_WithoutHTML");

                entity.Property(e => e.RequestType)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ShariaMode).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.ThumbNailFileName).HasMaxLength(200);

                entity.Property(e => e.ThumbNailFilePath).HasMaxLength(500);

                entity.Property(e => e.TumbnailImageUrl).HasMaxLength(500);

                entity.Property(e => e.VertexName).HasMaxLength(300);

                entity.HasOne(d => d.BranchNavigation)
                    .WithMany(p => p.UscTVertices)
                    .HasForeignKey(d => d.Branch)
                    .HasConstraintName("FK__usc_t_Ver__Branc__2B2A60FE");

                entity.HasOne(d => d.Charges)
                    .WithMany(p => p.UscTVertices)
                    .HasForeignKey(d => d.ChargesId)
                    .HasConstraintName("FK__usc_t_Ver__Charg__21A0F6C4");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.UscTVertices)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("FK__usc_t_Ver__Count__222B06A9");

                entity.HasOne(d => d.CriteriaNavigation)
                    .WithMany(p => p.UscTVertices)
                    .HasForeignKey(d => d.CriteriaId)
                    .HasConstraintName("FK__usc_t_Ver__Crite__23893F36");

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.UscTVertices)
                    .HasForeignKey(d => d.Department)
                    .HasConstraintName("FK__usc_t_Ver__Depar__2A363CC5");

                entity.HasOne(d => d.Loyalty)
                    .WithMany(p => p.UscTVertices)
                    .HasForeignKey(d => d.LoyaltyId)
                    .HasConstraintName("FK__usc_t_Ver__Loyal__247D636F");

                entity.HasOne(d => d.Rate)
                    .WithMany(p => p.UscTVertices)
                    .HasForeignKey(d => d.RateId)
                    .HasConstraintName("FK__usc_t_Ver__RateI__22951AFD");

                entity.HasOne(d => d.SegmentNavigation)
                    .WithMany(p => p.UscTVertices)
                    .HasForeignKey(d => d.Segment)
                    .HasConstraintName("FK__usc_t_Ver__Segme__7E8CC4B1");

                entity.HasOne(d => d.SubSegmentNavigation)
                    .WithMany(p => p.UscTVertices)
                    .HasForeignKey(d => d.SubSegment)
                    .HasConstraintName("FK__usc_t_Ver__Categ__257187A8");

                entity.HasOne(d => d.Tawazun)
                    .WithMany(p => p.UscTVertices)
                    .HasForeignKey(d => d.TawazunId)
                    .HasConstraintName("FK__usc_t_Ver__Tawaz__636EBA21");
            });

            modelBuilder.Entity<UscTVertexComplyAttachment>(entity =>
            {
                entity.ToTable("usc_t_VertexComplyAttachments");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttachmentUrl)
                    .HasMaxLength(500)
                    .HasColumnName("AttachmentURL");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.DeletedBy).HasMaxLength(255);

                entity.Property(e => e.FileName).HasMaxLength(200);

                entity.Property(e => e.Size).HasMaxLength(100);

                entity.Property(e => e.VertexId).HasColumnName("VertexID");
            });

            modelBuilder.Entity<UscTVertexApprover>(entity =>
            {
                entity.ToTable("usc_t_VertexApprover");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApproverEmailId).HasMaxLength(500);

                entity.Property(e => e.Createdby).HasMaxLength(500);

                entity.Property(e => e.VertexId).HasColumnName("vertexId");

                entity.HasOne(d => d.Vertex)
                    .WithMany(p => p.UscTVertexApprovers)
                    .HasForeignKey(d => d.VertexId)
                    .HasConstraintName("FK__usc_t_Ver__verte__0C66AE13");
            });

            modelBuilder.Entity<UscTVertexTransaction>(entity =>
            {
                entity.ToTable("usc_t_VertexTransactions");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttachmentUrl)
                    .HasMaxLength(500)
                    .HasColumnName("AttachmentURL");

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VertexId).HasColumnName("VertexID");

                entity.HasOne(d => d.Vertex)
                    .WithMany(p => p.UscTVertexTransactions)
                    .HasForeignKey(d => d.VertexId)
                    .HasConstraintName("FK__usc_t_Ver__Verte__0D5AD24C");
                entity.Property(e => e.FromPersonId)
.HasMaxLength(324)
.HasColumnName("FromPersonID");


                entity.Property(e => e.ToPersonId)
                    .HasMaxLength(324)
                    .HasColumnName("ToPersonID");

                entity.Property(e => e.TransactionByDisplayName)
                    .HasMaxLength(300)
                    .HasColumnName("TransactionBy_DisplayName");

                entity.Property(e => e.TransactionByRole)
                    .HasMaxLength(300)
                    .HasColumnName("TransactionBy_Role");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(507);

                entity.Property(e => e.DeletedBy).HasMaxLength(507);

                entity.Property(e => e.Department).HasMaxLength(200);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(507)
                    .HasColumnName("EmailID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ModifiedBy).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<UserRoleMapping>(entity =>
            {
                entity.ToTable("UserRoleMapping");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(507);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoleMappings)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__UserRoleM__RoleI__7E0DA1C4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoleMappings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserRoleM__UserI__7F01C5FD");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
