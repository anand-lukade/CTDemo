using Microsoft.SharePoint.Client;
using Repository.Models;
using System;
using Repository.Constants;
using System.Collections.Generic;

namespace Repository
{
    public static class UserService
    {
        public static UserInfo GetUserInfo()
        {
            try
            {
                using (var clientContext = new ClientContext("http://cmlbi.za.omlac.net/sites/gladius"))
                {
                    var spUser = clientContext.Web.CurrentUser;
                    UserInfo userInformation = GetUserTitle(clientContext, spUser);                    
                    GetGroupsForLoggedinUser(clientContext, spUser, userInformation);
                    GetUserDetails(clientContext, userInformation);
                    return userInformation;
                }
            }   
            catch(Exception ex)
            {
                //log into list about the error and throw generic error for user interface
                throw new ArgumentException("Something went wrong: "+ex.Message);
            }                 
        }

        internal static void GetUserDetails(ClientContext clientContext, UserInfo userInformation)
        {
            var buMailMaster = clientContext.Web.Lists.GetByTitle(ListConstants.BUMailMaster);
            CamlQuery query = new CamlQuery();
            ListItemCollection items = buMailMaster.GetItems(query);
            clientContext.Load(items);
            clientContext.ExecuteQuery();
            var userGroup = userInformation.Groups;
            MapBuMailMaster(userInformation, items, userGroup);
        }

        private static void MapBuMailMaster(UserInfo userInformation, ListItemCollection items, List<string> userGroup)
        {
            foreach (var item in items)
            {
                if (userGroup.Contains(Convert.ToString(item[ListColumnConstants.TLGroupName])) ||
                    userGroup.Contains(Convert.ToString(item[ListColumnConstants.OPSMGroupName])) ||
                    userGroup.Contains(Convert.ToString(item[ListColumnConstants.MISGroupName])) ||
                    userGroup.Contains(Convert.ToString(item[ListColumnConstants.SCGroupName])) ||
                    userGroup.Contains(Convert.ToString(item[ListColumnConstants.ActGroupName])) ||
                    userGroup.Contains(Convert.ToString(item[ListColumnConstants.CCGroupName])) ||
                    userGroup.Contains(Convert.ToString(item[ListColumnConstants.CCMISGroupName])))
                {
                    userInformation.userMasters.Add(new UserMaster()
                    {
                        Id = Convert.ToInt32(item[ListColumnConstants.ID]),
                        ActionListName = Convert.ToString(item[ListColumnConstants.ActListName]),
                        BusinessUnit = Convert.ToString(item[ListColumnConstants.BusinessUnit]),
                        ClListName = Convert.ToString(item[ListColumnConstants.CLListName]),
                        QaListName = Convert.ToString(item[ListColumnConstants.QAListName]),
                        RcaListName = Convert.ToString(item[ListColumnConstants.RCAListName]),
                        Segment = Convert.ToString(item[ListColumnConstants.Segment]),
                        TlGroupName = Convert.ToString(item[ListColumnConstants.TLGroupName]),
                        MISGroupName = Convert.ToString(item[ListColumnConstants.MISGroupName]),
                        OpsmGroupName = Convert.ToString(item[ListColumnConstants.OPSMGroupName]),
                        SCGroupName = Convert.ToString(item[ListColumnConstants.SCGroupName]),
                        ActGroupName = Convert.ToString(item[ListColumnConstants.ActGroupName]),
                        CCGroupName = Convert.ToString(item[ListColumnConstants.CCGroupName]),
                        CCMISGroupName = Convert.ToString(item[ListColumnConstants.CCMISGroupName]),
                    });
                }
            }
        }

        private static UserInfo GetUserTitle(ClientContext clientContext, User spUser)
        {
            clientContext.Load(spUser, user => user.Title);
            clientContext.Load(spUser, user => user.Email);
            clientContext.Load(spUser);
            clientContext.ExecuteQuery();
            UserInfo userInformation = new UserInfo()
            {
                Title = spUser.Title,
                Email = spUser.Email
            };
            return userInformation;
        }

        private static void GetGroupsForLoggedinUser(ClientContext clientContext, User spUser, UserInfo userInformation)
        {
            var web = clientContext.Web;
            var member = web.EnsureUser(spUser.Email);
            var groupCollection = member.Groups;
            clientContext.Load(groupCollection);
            clientContext.ExecuteQuery();
            foreach (Group group in groupCollection)
            {
                userInformation.Groups.Add(group.Title);
            }
        }
    }
}
