using System;
using System.Collections.Generic;
using System.ServiceModel;
using wSrvBridge.Logger;
using wSrvBridge.Lib;
using wSrvConnector.ServiceModels;
using wSrvConnector.ToskaServices;

namespace wSrvConnector
{
    public class ClubMembershipSearchService : ServiceBase, IClubMembershipSearchService, IDisposable
    {
        private toskaClubMembershipSearchOperationsWsPortClient _serviceClient;

        public override void InitializeService()
        {
            if (String.IsNullOrWhiteSpace(ConfigurationName))
            {
                _serviceClient = new toskaClubMembershipSearchOperationsWsPortClient();
            }
            else
            {
                var log = Logger.CreateNotificationLog(LogLevel.Connector, "ClubMembershipSearchService Initialized with custom configuration: " + ConfigurationName);
                log.Naming = WebServiceNaming.wsClubMembershipSearch.ToString();
                log.Operation = "InitializeService";
                Logger.Save(log);

                _serviceClient = new toskaClubMembershipSearchOperationsWsPortClient(ConfigurationName);
            }
        }

        public ClubMembershipResult BulkClubSearch(List<string> searchMsisdn, int searchClubId)
        {
            try
            {
                ClubMembershipSearchCriteria searchCriteria = new ClubMembershipSearchCriteria();
                searchCriteria.clubId = searchClubId;
                searchCriteria.clubType = 1;
                searchCriteria.listType = 0;
                searchCriteria.list = String.Join(",", searchMsisdn.ToArray());

                GenericClubMembershipLog[] searchResult = _serviceClient.clubMembershipSearchBulk(searchCriteria);
                return new ClubMembershipResult
                {
                    Success = true,
                    ResultSet = searchResult
                };
            }
            catch (Exception exc)
            {
                var log = Logger.CreateErrorLog(LogLevel.Connector, exc);
                log.Naming = WebServiceNaming.wsClubMembershipSearch.ToString();
                log.Operation = "BulkClubSearch";
                Logger.Save(log);

                return new ClubMembershipResult
                {
                    Success = false,
                    ResultSet = null
                };
            }
        }


        #region IDisposable Implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                bool success = false;
                if (_serviceClient != null)
                {
                    try
                    {
                        if (_serviceClient.State != CommunicationState.Faulted)
                        {
                            _serviceClient.Close();
                            success = true;

                            Logger.Save(Logger.CreateNotificationLog(LogLevel.Connector, "Service Client disposed successfully"));
                        }
                    }
                    finally
                    {
                        if (!success)
                        {
                            var log = Logger.CreateNotificationLog(LogLevel.Connector, "Service Client has recovered from CommunicationState.Faulted state");
                            Logger.Save(log);

                            _serviceClient.Abort();
                        }
                    }
                }
            }
        }
        #endregion
    }
}
