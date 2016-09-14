using System;
using System.Collections.Generic;
using wSrvConnector.ToskaServices;

namespace wSrvConnector.ServiceModels
{
    public class ClubMembershipResult
    {
        public bool Success { get; set; }
        public GenericClubMembershipLog[] ResultSet { get; set; }
    }
}
