using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace wSrvLocatorLibrary
{
    [ServiceContract]
    public interface IClubMembershipQueryService
    {
        [OperationContract]
        ClubMembershipQueryResult BulkClubSearch(List<string> msisdnList, int clubId);
    }

    [DataContract]
    public class ClubMembershipQueryResult
    {
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public List<string> MembersMsisdnList { get; set; }
    }
}
