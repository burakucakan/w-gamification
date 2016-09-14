using System;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace wSrvLocatorLibrary
{
    [ServiceContract]
    public interface IPermissionQueryService
    {
        [OperationContract]
        PermissionQueryResult GetServicePermission(string msisdn);

        [OperationContract]
        PermissionQueryResult WriteServicePermission(string msisdn, Permission permission);
    }

    [DataContract]
    public enum Permission
    {
        [EnumMember]
        PermissionGranted = 0,
        [EnumMember]
        PermissionDenied = 1
    }

    [DataContract]
    public class PermissionQueryResult
    {
        [DataMember]
        public string Permission { get; set; }
        [DataMember]
        public string ModifyDate { get; set; }
        [DataMember]
        public string ModifyUser { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public bool Success { get; set; }
    }
}
