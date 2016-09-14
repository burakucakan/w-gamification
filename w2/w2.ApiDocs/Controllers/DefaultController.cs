using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Resources;
using System.Text;
using System.Web;
using System.Web.Mvc;
using w2.Service;

namespace Gnc2.ServiceDoc.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Default()
        {
            srvWebServices srv = new srvWebServices();
            var model = srv.GetAll().Where(m => m.IsActive == true && m.IsDeleted == false);

            return View(model);
        }

        public JsonResult WebServicesParameters(int Id)
        {
            srvWebServiceParameters srv = new srvWebServiceParameters();
            var model = srv.GetAll().Where(m => m.WebServiceId == Id && m.WebServiceDirectionCode == 0);

            return Json(model.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult WebServiceRun(string Path)
        {
            try
            {
                using (var client = new WebClient())
                {
                    Path = Path.Replace("amp;", "&");
                    client.Encoding = Encoding.UTF8;

                    var response = client.DownloadString(Path);
                    if (response == "The remote server returned an error: (404) Not Found.")
                    {
                        return Json(new { statusCode = "OK", errorMessage = response }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(response, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { statusCode = "FAIL", errorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            
        }
    }
}
