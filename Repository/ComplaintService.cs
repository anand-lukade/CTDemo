using Microsoft.SharePoint.Client;
using Repository.Constants;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public static class ComplaintService
    {
        public static List<Complaint> GetAllComplaintsData(UserInfo userInfo)
        {
            try
            {
                using (var clientContext = new ClientContext("http://cmlbi.za.omlac.net/sites/gladius"))
                {
                    List<Complaint> compdata = new List<Complaint>();
                    var complaintListNames = userInfo.userMasters.Select(x => x.ClListName).Distinct();
                    foreach (var complaintListName in complaintListNames)
                    {
                        List announcementsList = clientContext.Web.Lists.GetByTitle(complaintListName);
                        CamlQuery query = new CamlQuery();
                        query.ViewXml = CamlQueryConstants.GetAllComplaintsDataQuery;
                        ListItemCollection items = announcementsList.GetItems(query);
                        clientContext.Load(items);
                        clientContext.ExecuteQuery();
                        foreach (ListItem listItem in items)
                        {
                            Microsoft.SharePoint.Client.TimeZone timeZoneSP = clientContext.Web.RegionalSettings.TimeZone;
                            clientContext.Load(timeZoneSP);
                            clientContext.ExecuteQuery();
                            var fixedTimeZoneName = timeZoneSP.Description.Replace("and", "&");
                            var timeZoneInfo = TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(tz => tz.DisplayName == fixedTimeZoneName);
                            var row = userInfo?.userMasters?.FirstOrDefault(x => x.ClListName == complaintListName);
                            string rcaListName = row ?.RcaListName;
                            string seg = row?.Segment;
                            bool pemissiontoWrite = CheckPermission(clientContext, complaintListName, userInfo.Groups);
                            Complaint result = MapComplaint(complaintListName, listItem, timeZoneInfo, rcaListName, pemissiontoWrite, seg);
                            compdata.Add(result);
                        }
                    }
                    if (compdata.Count > 0)
                    {
                        compdata = compdata.OrderByDescending(x => x.DateReceived).ToList();
                    }
                    return compdata;
                }
            }
            catch (Exception ex)
            {
                //log to list              
                throw new ArgumentException("Something went wrong: " + ex.Message);
            }
        }

        private static Complaint MapComplaint(string complaintListName, ListItem listItem, TimeZoneInfo timeZoneInfo, string rcaListName, bool pemissiontoWrite, string seg)
        {
            var result = new Complaint()
            {
                Reference = Convert.ToString(listItem[ListColumnConstants.CompRef]),
                EmsCaseReference = Convert.ToString(listItem[ListColumnConstants.EMSCaseRef]),
                MailboxName = Convert.ToString(listItem[ListColumnConstants.MailboxName]),
                MemberCode = Convert.ToString(listItem[ListColumnConstants.MemCode]),
                Surname = Convert.ToString(listItem[ListColumnConstants.Surname]),
                SchemePolicyContractNo = Convert.ToString(listItem[ListColumnConstants.SchmePlcyContractNo]),
                Source = Convert.ToString(listItem[ListColumnConstants.Source]),
                SourceType = Convert.ToString(listItem[ListColumnConstants.CompSourceType]),
                DepartmentInvolved = Convert.ToString(listItem[ListColumnConstants.DeptInvolved]),
                RelatedProcess = Convert.ToString(listItem[ListColumnConstants.ReltdProcess]),
                Levels = Convert.ToString(listItem[ListColumnConstants.Levels]),
                PreviousLevelComp = Convert.ToString(listItem[ListColumnConstants.PrevLevel1Comp]),
                DateReceived = TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(listItem[ListColumnConstants.DateTimeReceived]), timeZoneInfo),
                ExtensionRequested = Convert.ToString(listItem[ListColumnConstants.ExtnRequested]),
                ExtensionRequestedComment = Convert.ToString(listItem[ListColumnConstants.ExtnReqComment]),
                ProductType = Convert.ToString(listItem[ListColumnConstants.ProductType]),
                BenefitType = Convert.ToString(listItem[ListColumnConstants.BenefitType]),
                BenefitDetail = Convert.ToString(listItem[ListColumnConstants.BenefitDetail]),
                Category = Convert.ToString(listItem[ListColumnConstants.CompCategory]),
                TcfComplaintOutcome = Convert.ToString(listItem[ListColumnConstants.TCFCompOutcome]),
                TcfComplaintRelatedTo = Convert.ToString(listItem[ListColumnConstants.TCFCompReltdTo]),
                DepartmentAtFault = Convert.ToString(listItem[ListColumnConstants.DeptAtFault]),
                RelatedToFund = Convert.ToString(listItem[ListColumnConstants.ReltdToFund]),
                Outcome = Convert.ToString(listItem[ListColumnConstants.Outcome]),
                Status = Convert.ToString(listItem[ListColumnConstants.Status]),
                WriteOffAmount = Convert.ToString(listItem[ListColumnConstants.WriteOffAmtInRands]),
                RootCauseAnalysis = Convert.ToString(listItem[ListColumnConstants.RCAnalysis]),
                SpId = Convert.ToInt16(listItem[ListColumnConstants.ID]),
                ComplaintResponder = Convert.ToString(listItem[ListColumnConstants.CompRespUser]),
                ClosedwithinSLA = Convert.ToString(listItem[ListColumnConstants.ClosedwithinSLA]),
                RCAFindings = Convert.ToString(listItem[ListColumnConstants.RCAFindings]),
                TlComplaintOwner = Convert.ToString(listItem[ListColumnConstants.TLComplaintOwner]),
                ComplaintTheme = Convert.ToString(listItem[ListColumnConstants.ComplaintTheme]),
                LitigationAction = Convert.ToString(listItem[ListColumnConstants.RefForLitignLegalAct]),
                FinancialImpact = Convert.ToString(listItem[ListColumnConstants.TypeOfFinImpact]),
                ReasonForSlaBreach = Convert.ToString(listItem[ListColumnConstants.ReasonSLABreach]),
                IdNumber = Convert.ToString(listItem[ListColumnConstants.CompIDNumber]),
                ClName = complaintListName,
                RcaName = rcaListName,
                HasPermission = true,
                CanWrite = pemissiontoWrite
            };
            if (listItem[ListColumnConstants.RCACompletionDate] != null)
            {
                result.RcTargetCompletionDate = TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(listItem[ListColumnConstants.RCACompletionDate]), timeZoneInfo);
            }
            if (listItem[ListColumnConstants.QryClosedDateRspnd] != null)
            {
                result.QueryClosedDate = TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(listItem[ListColumnConstants.QryClosedDateRspnd]), timeZoneInfo);
            }
            if (listItem[ListColumnConstants.RenegoDueDate] != null)
            {
                result.RenegotiatedDueDate = TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(listItem[ListColumnConstants.RenegoDueDate]), timeZoneInfo);
            }
            result.SegmentName = seg;
            if (listItem[seg + ListColumnConstants.RCAID] != null)
            {
                FieldLookupValue lookuprca = listItem[seg + ListColumnConstants.RCAID] as FieldLookupValue;
                result.RcId = lookuprca.LookupId.ToString();
            }
            if (listItem[ListColumnConstants.TLComplaintOwner] != null)
            {
                FieldLookupValue lookup = listItem[ListColumnConstants.TLComplaintOwner] as FieldLookupValue;
                result.TlComplaintOwner = lookup.LookupValue;
            }

            return result;
        }

        internal static bool CheckPermission(ClientContext clientContext, string listName, List<string> groups)
        {
            if (!(groups != null && groups.Count > 0))
            {
                return false;
            }
            ListItemCollection items = ReadPemissions(clientContext, listName);
            if (items.Count > 0)
            {
                foreach (var listItem in items)
                {
                    var groupName = Convert.ToString(listItem[ListColumnConstants.SecurityGroupName]);
                    if (groups.Contains(groupName))
                    {
                        var permission = Convert.ToString(listItem[ListColumnConstants.PermissionLevel]);
                        if (permission != ListColumnConstants.Read)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private static ListItemCollection ReadPemissions(ClientContext clientContext, string listName)
        {
            List pemissions = clientContext.Web.Lists.GetByTitle(ListConstants.PermissionAdministration);
            CamlQuery query = new CamlQuery();
            query.ViewXml = CamlQueryConstants.CheckPermissionQuery.Replace("listNameToReplace", listName);
            ListItemCollection items = pemissions.GetItems(query);
            clientContext.Load(items);
            clientContext.ExecuteQuery();
            return items;
        }

        public static Complaint GetComplaint(int id, string cllistName, string seg)
        {
            try
            {
                using (var clientContext = new ClientContext("http://cmlbi.za.omlac.net/sites/gladius"))
                {
                    List complaints = clientContext.Web.Lists.GetByTitle(cllistName);
                    string query = string.Format(CamlQueryConstants.GetComplaintQuery, id);
                    var q = new CamlQuery() { ViewXml = query };
                    ListItemCollection items = complaints.GetItems(q);
                    Microsoft.SharePoint.Client.TimeZone timeZoneSP = clientContext.Web.RegionalSettings.TimeZone;
                    clientContext.Load(timeZoneSP);
                    clientContext.Load(items);
                    clientContext.ExecuteQuery();
                    ListItem listItem = items.FirstOrDefault(x => x.Id == id);
                    var fixedTimeZoneName = timeZoneSP.Description.Replace("and", "&");
                    var timeZoneInfo = TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(tz => tz.DisplayName == fixedTimeZoneName);
                    var result = new Complaint()
                    {
                        Reference = Convert.ToString(listItem[ListColumnConstants.CompRef]),
                        EmsCaseReference = Convert.ToString(listItem[ListColumnConstants.EMSCaseRef]),
                        MailboxName = Convert.ToString(listItem[ListColumnConstants.MailboxName]),
                        MemberCode = Convert.ToString(listItem[ListColumnConstants.MemCode]),
                        Surname = Convert.ToString(listItem[ListColumnConstants.Surname]),
                        SchemePolicyContractNo = Convert.ToString(listItem[ListColumnConstants.SchmePlcyContractNo]),
                        Source = Convert.ToString(listItem[ListColumnConstants.Source]),
                        SourceType = Convert.ToString(listItem[ListColumnConstants.CompSourceType]),
                        DepartmentInvolved = Convert.ToString(listItem[ListColumnConstants.DeptInvolved]),
                        RelatedProcess = Convert.ToString(listItem[ListColumnConstants.ReltdProcess]),
                        Levels = Convert.ToString(listItem[ListColumnConstants.Levels]),
                        PreviousLevelComp = Convert.ToString(listItem[ListColumnConstants.PrevLevel1Comp]),
                        DateReceived = TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(listItem[ListColumnConstants.DateTimeReceived]), timeZoneInfo),
                        ExtensionRequested = Convert.ToString(listItem[ListColumnConstants.ExtnRequested]),
                        ExtensionRequestedComment = Convert.ToString(listItem[ListColumnConstants.ExtnReqComment]),
                        ProductType = Convert.ToString(listItem[ListColumnConstants.ProductType]),
                        BenefitType = Convert.ToString(listItem[ListColumnConstants.BenefitType]),
                        BenefitDetail = Convert.ToString(listItem[ListColumnConstants.BenefitDetail]),
                        Category = Convert.ToString(listItem[ListColumnConstants.CompCategory]),
                        TcfComplaintOutcome = Convert.ToString(listItem[ListColumnConstants.TCFCompOutcome]),
                        TcfComplaintRelatedTo = Convert.ToString(listItem[ListColumnConstants.TCFCompReltdTo]),
                        DepartmentAtFault = Convert.ToString(listItem[ListColumnConstants.DeptAtFault]),
                        RelatedToFund = Convert.ToString(listItem[ListColumnConstants.ReltdToFund]),
                        Outcome = Convert.ToString(listItem[ListColumnConstants.Outcome]),
                        Status = Convert.ToString(listItem[ListColumnConstants.Status]),
                        WriteOffAmount = Convert.ToString(listItem[ListColumnConstants.WriteOffAmtInRands]),
                        RootCauseAnalysis = Convert.ToString(listItem[ListColumnConstants.RCAnalysis]),
                        ComplaintResponder = Convert.ToString(listItem[ListColumnConstants.CompRespUser]),
                        ClosedwithinSLA = Convert.ToString(listItem[ListColumnConstants.ClosedwithinSLA]),
                        RCAFindings = Convert.ToString(listItem[ListColumnConstants.RCAFindings]),
                        TlComplaintOwner = Convert.ToString(listItem[ListColumnConstants.TLComplaintOwner]),
                        ComplaintTheme = Convert.ToString(listItem[ListColumnConstants.ComplaintTheme]),
                        LitigationAction = Convert.ToString(listItem[ListColumnConstants.RefForLitignLegalAct]),
                        FinancialImpact = Convert.ToString(listItem[ListColumnConstants.TypeOfFinImpact]),
                        ReasonForSlaBreach = Convert.ToString(listItem[ListColumnConstants.ReasonSLABreach]),
                        IdNumber = Convert.ToString(listItem[ListColumnConstants.CompIDNumber])
                    };
                    if (listItem[ListColumnConstants.RCACompletionDate] != null)
                    {
                        result.RcTargetCompletionDate = TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(listItem[ListColumnConstants.RCACompletionDate]), timeZoneInfo);
                    }
                    if (listItem[ListColumnConstants.QryClosedDateRspnd] != null)
                    {
                        result.QueryClosedDate = TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(listItem[ListColumnConstants.QryClosedDateRspnd]), timeZoneInfo);
                    }
                    if (listItem[ListColumnConstants.RenegoDueDate] != null)
                    {
                        result.RenegotiatedDueDate = TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(listItem[ListColumnConstants.RenegoDueDate]), timeZoneInfo);
                    }
                    result.SegmentName = seg;
                    if (listItem[seg + ListColumnConstants.RCAID] != null)
                    {
                        FieldLookupValue lookuprca = listItem[seg + ListColumnConstants.RCAID] as FieldLookupValue;
                        result.RcId = lookuprca.LookupId.ToString();
                    }
                    if (listItem[ListColumnConstants.TLComplaintOwner] != null)
                    {
                        FieldLookupValue lookup = listItem[ListColumnConstants.TLComplaintOwner] as FieldLookupValue;
                        result.TlComplaintOwner = lookup.LookupValue;
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Something went wrong: " + ex.Message);
            }
        }
    }
}
