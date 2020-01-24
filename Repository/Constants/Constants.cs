namespace Repository.Constants
{
    public static class ListConstants
    {
        public const string ErrorLog = "ErrorLog";
        public const string PermissionAdministration = "PermissionAdministration";
        public const string PageLinks = "PageLinks";
        public const string Log = "Log";
        public const string QaQuestionsMaster = "QA Questions Master";
        public const string BUMailMaster = "BUMailMaster";
    }
    public static class ListColumnConstants
    {
        #region BuMailMasterList
        public const string TLGroupName = "TLGroupName";
        public const string OPSMGroupName = "OPSMGroupName";
        public const string MISGroupName = "MISGroupName";
        public const string SCGroupName = "SCGroupName";
        public const string ActGroupName = "ActGroupName";
        public const string CCGroupName = "CCGroupName";
        public const string CCMISGroupName = "CCMISGroupName";
        public const string ActListName = "ActListName";
        public const string BusinessUnit = "BusinessUnit";
        public const string CLListName = "CLListName";
        public const string QAListName = "QAListName";
        public const string RCAListName = "RCAListName";
        public const string Segment = "Segment";
        //public const string
        #endregion

        public const string RCAID = "RCAID";
        public const string ACTION = "ACTION";
        #region ActionListConstants
        public const string ActItemCode = "ActItemCode";
        public const string ActOwnerName = "ActOwnerName";
        public const string ActOwner = "ActOwner";
        public const string ActItemShortDesc = "ActItemShortDesc";
        public const string ActDetldDesc = "ActDetldDesc";
        public const string ID = "ID";
        public const string CurrentStatus = "CurrentStatus";
        public const string Created = "Created";
        public const string ActlStartDate = "ActlStartDate";
        public const string PerCompln = "PerCompln";
        public const string DueDate = "DueDate";
        public const string RevisedDueDate = "RevisedDueDate";
        public const string ActlComplnDate = "ActlComplnDate";
        public const string ActionFactor = "ActionFactor";
        #endregion
        #region ErrorMessage
        public const string Message = "Message";
        public const string Details = "Details";
        public const string LogTime = "LogTime";
        public const string escalate = "~\\escalate.txt";
        #endregion
        #region SecurityGroup
        public const string SecurityGroupName = "SecurityGroupName";
        public const string PermissionLevel = "PermissionLevel";
        public const string Read = "Read";
        #endregion
        #region ReportList
        public const string Title = "Title";
        public const string LinkType = "LinkType";
        public const string URL = "URL";
        public const string ListName = "ListName";
        #endregion
        #region QAComplaintList
        public const string DateTimeReceived = "DateTimeReceived";
        public const string CompRef = "CompRef";
        public const string EMSCaseRef = "EMSCaseRef";
        public const string MailboxName = "MailboxName";
        public const string ProductType = "ProductType";
        public const string Surname = "Surname";
        public const string Status = "Status";
        public const string QARating = "QARating";
        public const string QADate = "QADate";
        public const string MinStdAchieved = "MinStdAchieved";
        public const string ResNonAdherence = "ResNonAdherence";
        public const string RCAnalysis = "RCAnalysis";
        public const string CallBackCompleted = "CallBackCompleted";
        public const string WasClientSatisfied = "WasClientSatisfied";
        public const string ReasonNotCompCallBack = "ReasonNotCompCallBack";
        public const string QACompleted = "QACompleted";
        public const string Yes = "Yes";
        public const string Question1 = "Question1";
        public const string Question2 = "Question2";
        public const string Question3 = "Question3";
        public const string Question4 = "Question4";
        public const string Question5 = "Question5";
        public const string Question6 = "Question6";
        public const string Question7 = "Question7";
        public const string Question8 = "Question8";
        public const string Question9 = "Question9";
        public const string Question10 = "Question10";
        public const string Weightage = "Weightage";
        public const string Q = "Q";
        public const string Rating = "Rating";
        public const string MemCode = "MemCode";
        public const string SchmePlcyContractNo = "SchmePlcyContractNo";
        public const string Source = "Source";
        public const string CompSourceType = "CompSourceType";
        public const string DeptInvolved = "DeptInvolved";
        public const string ReltdProcess = "ReltdProcess";
        public const string Levels = "Levels";
        public const string PrevLevel1Comp = "PrevLevel1Comp";
        public const string QryClosedDateRspnd = "QryClosedDateRspnd";
        public const string ExtnRequested = "ExtnRequested";
        public const string ExtnReqComment = "ExtnReqComment";
        public const string RenegoDueDate = "RenegoDueDate";
        public const string BenefitType = "BenefitType";
        public const string BenefitDetail = "BenefitDetail";
        public const string CompCategory = "CompCategory";
        public const string TCFCompOutcome = "TCFCompOutcome";
        public const string TCFCompReltdTo = "TCFCompReltdTo";
        public const string DeptAtFault = "DeptAtFault";
        public const string ReltdToFund = "ReltdToFund";
        public const string Outcome1 = "Outcome1";
        public const string WriteOffAmtInRands = "WriteOffAmtInRands";
        public const string RCTgtCompLitDate = "RCTgtCompLitDate";
        public const string RefForLitignLegalAct = "RefForLitignLegalAct";
        public const string ReasonSLABreach = "ReasonSLABreach";
        public const string Id = "Id";
        #endregion
        #region rcalistconstants
        public const string corp = "corp";
        public const string Corporate = "Corporate";
        public const string _RCA = "_RCA";
        public const string RCOwner = "RCOwner";
        public const string RCInvestigationTeam = "RCInvestigationTeam";
        public const string FivewhyAnalysis = "FivewhyAnalysis";
        public const string RootCause = "RootCause";
        public const string RCTheme = "RCTheme";
        public const string RCFactor = "RCFactor";
        public const string RCOwnerName = "RCOwnerName";
        public const string RCID = "RCID";
        public const string ComplaintDesc = "ComplaintDesc";
        #endregion
        #region ComplaintListData
        public const string Outcome = "Outcome";
        public const string CompRespUser = "CompRespUser";
        public const string ClosedwithinSLA = "ClosedwithinSLA";
        public const string RCAFindings = "RCAFindings";
        public const string TLComplaintOwner = "TLComplaintOwner";
        public const string ComplaintTheme = "ComplaintTheme";
        public const string TypeOfFinImpact = "TypeOfFinImpact";
        public const string CompIDNumber = "CompIDNumber";
        public const string RCACompletionDate = "RCACompletionDate";


        #endregion
    }

    public static class GroupConstants
    {
        public const string AllMis = "ALL MIS";
        public const string CorpMis = "CORP MIS";
        public const string MfcMis = "MFC MIS";
        public const string CentralComplaintsMis = "CENTRAL COMPLAINTS MIS";
        public const string PfMis = "PF MIS";
        public const string WealthMis = "WEALTH MIS";
        public const string CtOwners = "CT Owners";
        public const string TL = "TL";
        public const string OPSM = "OPSM";
    }
    public static class UserMessages
    {
        public const string InvalidUser = "Invalid User";
    }
    public static class CamlQueryConstants
    {
        public const string GetAllActionForLoggedInUser = "<View><Query><Where><Or><Eq><FieldRef Name='CurrentStatus' /><Value Type='Choice'>Not started</Value></Eq><Eq><FieldRef Name='CurrentStatus'/><Value Type='Choice'>In progress</Value></Eq></Or></Where></Query></View>";
        public const string DateFormattingForApp = "yyyy-MM-dd";
        public const string CheckPermissionQuery = "<View><Query><Where><Eq><FieldRef Name='ListDisplayName' /><Value Type='Text'>listNameToReplace</Value></Eq></Where></Query></View>";
        public const string ReportQuery = "<View><Query><Where><Eq><FieldRef Name='LinkType' /><Value Type='Text'>Reports</Value></Eq></Where></Query></View>";
        public const string SearchQuery = "<View><Query><Where><Eq><FieldRef Name='LinkType' /><Value Type='Text'>Search</Value></Eq></Where></Query></View>";
        public const string MasterListQuery = "<View><Query><Where><Eq><FieldRef Name='LinkType' /><Value Type='Text'>Master Lists</Value></Eq></Where></Query></View>";
        public const string SecurityGroupQuery = "<View><Query><Where><Eq><FieldRef Name='LinkType' /><Value Type='Text'>Security Group</Value></Eq></Where></Query></View>";
        public const string ClosedComplaintQuery = "<View><Query><Where><And><IsNotNull><FieldRef Name='QryClosedDateRspnd'/></IsNotNull><Or><IsNull><FieldRef Name='QACompleted' /></IsNull><Eq><FieldRef Name='QACompleted' /><Value Type='Choice'>No</Value></Eq></Or></And></Where></Query></View>";
        public const string ClosedComplaintsWithQADone = "<View> <Query><Where><And><Eq><FieldRef Name='Status' /><Value Type='Text'>No</Value></Eq><Eq><FieldRef Name='QACompleted'/><Value Type='Text'>Yes</Value></Eq></And></Where></Query> </View>";
        public const string GetComplaintQuery = "<View><Query><Where><Eq><FieldRef Name='ID' /><Value Type='Counter'>{0}</Value></Eq></Where></Query></View>";
        //public const string GetComplaintByEmsQuery = "<View><Query><Where><Eq><FieldRef Name='EMSCaseRef' /><Value Type='Text'>{0}</Value></Eq></Where></Query></View>";
        public const string GetComplaintByEmsQuery = "<View><Query><Where><And><Or><Eq><FieldRef Name='QACompleted' /><Value Type='Choice'>No</Value></Eq><IsNull><FieldRef Name='QACompleted'/></IsNull></Or><Eq><FieldRef Name='EMSCaseRef' /><Value Type='Text'>{0}</Value></Eq></And></Where></Query></View>";
        public const string GetAllComplaintsDataQuery = "<View> <Query><Where><Or><Eq><FieldRef Name='QACompleted' /><Value Type='Choice'>No</Value></Eq><IsNull><FieldRef Name='QACompleted'/></IsNull></Or></Where></Query> </View>";
        public const string GetClosedComplaintByEmsQuery = "<View><Query><Where><And>" + "<Or><IsNull><FieldRef Name='QACompleted' /></IsNull>" +
                                                    "<Eq><FieldRef Name='QACompleted' /> <Value Type='Choice'>No</Value> </Eq>" +
                                                    "</Or><And><IsNotNull><FieldRef Name='QryClosedDateRspnd' /> </IsNotNull>" +
                                                    "<Eq> <FieldRef Name='EMSCaseRef' /><Value Type='Text'>{0}</Value></Eq></And> </And> </Where></Query></View>";
    }
}
