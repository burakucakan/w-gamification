using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Gnc2.App_Manager;
using Gnc2.Models;
using Gnc2.Web.App_Manager;


namespace Gnc2.Controllers
{
    public class BaseController : Controller
    {

        protected SessionManager session { get { return SessionManager.GetInstance(); } }
        protected ConfigManager config { get { return ConfigManager.GetInstance(); } }

        protected string GetHeaderMsisdn()
        {
            #region :: Local Fake Logic ::
            if (LIB.Util.IsLocal())
                return session.LocalMsisdn;
            #endregion 

            var reqHeaders = System.Web.HttpContext.Current.Request.Headers;
            return reqHeaders[ConfigManager.GetInstance().TurkcellSsoHeaderName] == null ? String.Empty : reqHeaders[ConfigManager.GetInstance().TurkcellSsoHeaderName].ToString();
        }

        protected ActionResult PartialResultSuccess()
        {
            return PartialView("Common/Result",
                new ResultModel
                {
                    Type = ResultModel.ResultType.success,
                    Message = "Success"
                });
        }

        protected ActionResult PartialResultError()
        {
            return PartialView("Common/Result",
                new ResultModel
                {
                    Type = ResultModel.ResultType.error,
                    Message = "Error"
                });
        }
    }
}