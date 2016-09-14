using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using w2.Service.Gigya;


namespace w2.Ws.Models
{
    [DataContract]
    public class BaseWsModel : BaseResponse
    {
        public bool HasErrors() { return this.ErrorCode != (int)ResponseCodes.ErrorCode.NoError; }

        public void SetDefaults(BaseResponse inputObj)
        {
            this.CallId = inputObj.CallId;
            this.ErrorCode = inputObj.ErrorCode;
            this.ErrorDetails = inputObj.ErrorDetails;
            this.ErrorMessage = inputObj.ErrorMessage;
            this.StatusCode = inputObj.StatusCode;
            this.StatusReason = inputObj.StatusReason;
        }
        
        
        

        
    }
}