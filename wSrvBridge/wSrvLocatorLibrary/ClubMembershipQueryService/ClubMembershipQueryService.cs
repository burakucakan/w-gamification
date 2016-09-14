using System;
using System.Collections.Generic;
using System.Linq;
using wSrvBridge.Lib;
using wSrvConnector;
using wSrvConnector.ServiceModels;
using wSrvBridge.Logger;

namespace wSrvLocatorLibrary
{
    public class ClubMembershipQueryService : IClubMembershipQueryService
    {
        public ClubMembershipQueryResult BulkClubSearch(List<string> msisdnList, int clubId)
        {
            ClubMembershipQueryResult result = new ClubMembershipQueryResult();
            result.Success = false;
            
            try
            {
                using (ClubMembershipSearchService serviceClient = ServiceFactory<ClubMembershipSearchService>.GetServiceClient(WebServiceNaming.wsClubMembershipSearch))
                {
                    serviceClient.InitializeService();
                    ClubMembershipResult connectorResult = serviceClient.BulkClubSearch(msisdnList, clubId);
                    if (connectorResult.Success == true)
                    {
                        result.Success = true;
                        result.MembersMsisdnList = new List<string>();
                        foreach (var clubMember in connectorResult.ResultSet)
                        {
                            result.MembersMsisdnList.Add(clubMember.msisdn);
                        }
                    }
                }

                var log = Logger.CreateNotificationLog(LogLevel.Library, "BulkClubSearch call successfull");
                log.Naming = WebServiceNaming.wsClubMembershipSearch.ToString();
                log.Operation = "BulkClubSearch";
                Logger.Save(log);
            }
            catch (Exception exc)
            {
                var log = Logger.CreateErrorLog(LogLevel.Library, exc);
                log.Naming = WebServiceNaming.wsClubMembershipSearch.ToString();
                log.Operation = "BulkClubSearch";

                Logger.Save(log);
            }

            return result;
        }
    }
}
