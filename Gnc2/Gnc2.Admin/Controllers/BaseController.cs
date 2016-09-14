using Gnc2.Admin.App_Manager;
using Gnc2.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gnc2.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected SessionManager session { get { return SessionManager.GetInstance(); } }

        protected ConfigManager config { get { return ConfigManager.GetInstance(); } }

        protected ActionResult PartialResultSuccess()
        {
            return PartialView("Common/Result",
                new ResultModel
                {
                    Type = ResultModel.ResultType.success,
                    Message = (string)HttpContext.GetGlobalResourceObject("Notices", "Success")
                });
        }

        protected ActionResult PartialResultError()
        {
            return PartialView("Common/Result",
                new ResultModel
                {
                    Type = ResultModel.ResultType.error,
                    Message = (string)HttpContext.GetGlobalResourceObject("Notices", "Error")
                });
        }

        protected ActionResult PartialResult(string content)
        {
            return PartialView("Common/Result",
                new ResultModel
                {
                    Message = content
                });
        }

        protected ActionResult ViewMain()
        {
            return RedirectToAction("Default", "Default");
        }

        protected ActionResult ViewLogin()
        {
            return RedirectToAction("Default", "Login");
        }
        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue
            };
        }

    }
}