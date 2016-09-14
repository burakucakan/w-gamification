using System;
using System.Collections.Generic;
using wSrvConnector.ServiceModels;

namespace wSrvConnector
{
    public interface IClubMembershipSearchService : IServiceConnector
    {
        ClubMembershipResult BulkClubSearch(List<string> searchMsisdn, int searchClubId);
    }
}
