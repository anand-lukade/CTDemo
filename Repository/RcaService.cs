using Microsoft.SharePoint.Client;
using Repository.Constants;
using Repository.Models;
using System;
using System.Collections.Generic;

namespace Repository
{
    public static class RcaService
    {
        public static List<RootCauseAnalysis> GetRcasForDropDown(string listName)
        {
            List<RootCauseAnalysis> rcas = null;
            try
            {
                using (var clientContext = new ClientContext("http://cmlbi.za.omlac.net/sites/gladius"))
                {
                    List announcementsList = clientContext.Web.Lists.GetByTitle(listName);

                    CamlQuery query = CamlQuery.CreateAllItemsQuery();
                    ListItemCollection items = announcementsList.GetItems(query);
                    clientContext.Load(items);
                    clientContext.ExecuteQuery();
                    rcas = new List<RootCauseAnalysis>();
                    foreach (ListItem listItem in items)
                    {
                        rcas.Add(new RootCauseAnalysis()
                        {
                            Id = Convert.ToString(listItem[ListColumnConstants.ID]),
                            Title = Convert.ToString(ListColumnConstants.Title)
                        });
                    }
                    return rcas;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Oops something went wrong: "+ex.Message);
            }
        }
    }
}
