using System.Collections.Generic;

namespace Repository.Models
{
    public class UserInfo
    {
        public string Title { get; set; }
        public string Email { get; set; }
        public List<string> Groups { get; set; } = new List<string>();
        public List<UserMaster> userMasters { get; set; } = new List<UserMaster>();
    }
    public class UserMaster
    {
        public int Id { get; set; }
        public string Segment { get; set; }
        public string BusinessUnit { get; set; }
        public string MailBoxName { get; set; }
        public string OperationManager { get; set; }
        public string ComplaintTl { get; set; }
        public string OperationManagerEmail { get; set; }
        public string ComplaintTlEmail { get; set; }
        public string ClListName { get; set; }
        public string RcaListName { get; set; }
        public string ActionListName { get; set; }
        public string QaListName { get; set; }
        public string TlGroupName { get; set; }
        public string OpsmGroupName { get; set; }
        public string MISGroupName { get; set; }
        public string SCGroupName { get; set; }
        public string ActGroupName { get; set; }
        public string CCGroupName { get; set; }
        public string CCMISGroupName { get; set; }
    }
}
