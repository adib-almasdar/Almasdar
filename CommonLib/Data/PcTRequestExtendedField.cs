using System;
using System.Collections.Generic;

namespace CommonLib.Data
{
    public partial class PcTRequestExtendedField
    {
        public int Id { get; set; }
        public int? RequestId { get; set; }
        public int? Organization { get; set; }
        public int? Division { get; set; }
        public int? Prupose { get; set; }
        public int? BusinessUnit { get; set; }
        public int? ShariaMode { get; set; }
        public int? Types { get; set; }
        public int? SubjectInstrument { get; set; }
        public string? ProductConceptName { get; set; }
        public string? Description { get; set; }
        public int? ProductConceptApprovalId { get; set; }
        public int? ProductApprovalId { get; set; }
        public int? ModifyTawazunId { get; set; }
        public int? Segment { get; set; }
        public string? LegalAssignedTo { get; set; }
        public string? LegalStatus { get; set; }
        public string? Principles { get; set; }
        public int? SubSidiary { get; set; }

        public virtual PcMBusinessUnit? BusinessUnitNavigation { get; set; }
        public virtual PcMDivision? DivisionNavigation { get; set; }
        public virtual PcMOrganisation? OrganizationNavigation { get; set; }
        public virtual PcMPurpose? PruposeNavigation { get; set; }
        public virtual HdTRequest? Request { get; set; }
        public virtual PcMSegment? SegmentNavigation { get; set; }
        public virtual PcMShariaMode? ShariaModeNavigation { get; set; }
        public virtual PcMSubjectOrInstrument? SubjectInstrumentNavigation { get; set; }
        public virtual PcMType? TypesNavigation { get; set; }
    }
}
