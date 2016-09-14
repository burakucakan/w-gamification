using System;

namespace wSrvConnector.ServiceModels
{
    public enum PermissionServiceOptout
    {
        PermissionGranted = 0,
        PermissionDenied = 1,
        NoPermissionRecord = 2,
        ServiceExceptionOccured = 3
    }

    public class PermissionServiceResult
    {
        public PermissionServiceOptout Permission { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyUser { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
