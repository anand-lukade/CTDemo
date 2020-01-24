using System;

namespace Repository.Models
{
    public class Complaint
    {        
        public string Reference { get; set; }
        public string EmsCaseReference { get; set; }
        public string MailboxName { get; set; }
        public string SchemePolicyContractNo { get; set; }
        public string MemberCode { get; set; }
        public string IdNumber { get; set; }
        public string Surname { get; set; }
        public string Source { get; set; }
        public string SourceType { get; set; }
        public string DepartmentInvolved { get; set; }
        public string RelatedProcess { get; set; }
        public string Levels { get; set; }
        public string PreviousLevelComp { get; set; }
        public DateTime DateReceived { get; set; }
        public DateTime? QueryClosedDate { get; set; }
        public string ExtensionRequested { get; set; }
        public string ExtensionRequestedComment { get; set; }        
        public DateTime? RenegotiatedDueDate { get; set; }        
        public string ProductType { get; set; }        
        public string BenefitType { get; set; }        
        public string BenefitDetail { get; set; }        
        public string Category { get; set; }        
        public string TcfComplaintOutcome { get; set; }        
        public string TcfComplaintRelatedTo { get; set; }        
        public string EducationToBusiness { get; set; }        
        public string DepartmentAtFault { get; set; }        
        public string RelatedToFund { get; set; }                
        public string Outcome { get; set; }        
        public string Status { get; set; }        
        public string TlComplaintOwner { get; set; }       
        public DateTime? RcTargetCompletionDate { get; set; }       
        public string WriteOffAmount { get; set; }      
        public string RootCauseAnalysis { get; set; }
        public int SpId { get; set; }
        public string SegmentName { get; set; }
        public string ClName { get; set; }
        public string RcaName { get; set; }
        public string QaList { get; set; }        
        public string ComplaintResponder { get; set; }       
        public string ClosedwithinSLA { get; set; }        
        public string RCAFindings { get; set; }        
        public string ComplaintTheme { get; set; }       
        public string LitigationAction { get; set; }        
        public string FinancialImpact { get; set; }        
        public string RcId { get; set; }       
        public string ReasonForSlaBreach { get; set; }
        public bool CanWrite { get; set; } = false;
        public bool HasPermission { get; set; } = false;
        public string RcaTitle { get; set; }
    }
}
