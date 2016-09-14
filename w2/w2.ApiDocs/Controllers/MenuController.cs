using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using w2.Service;

namespace Gnc2.ServiceDoc.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/

        
        
        public PartialViewResult Default()
        {
            srvWebServices srv = new srvWebServices();
            var model = srv.GetAll().Where(m => m.IsActive == true && m.IsDeleted == false);
            return PartialView(model);
        }

        public JsonResult WebServiceDetail(int Id)
        {
            srvWebServices srv = new srvWebServices();
            var model = srv.GetById(Id);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult WebServiceRequestParameters(int Id)
        {
            srvWebServiceParameters srv = new srvWebServiceParameters();
            var model = srv.GetAll().Where(m => m.WebServiceId == Id && m.WebServiceDirectionCode == 0);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult WebServiceResponseParameters(int Id)
        {
            srvWebServiceParameters srv = new srvWebServiceParameters();
            var model = srv.GetAll().Where(m => m.WebServiceId == Id && m.WebServiceDirectionCode == 1);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

    }
}
