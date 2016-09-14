using Gnc2.App_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gnc2.Controllers
{
    public class JsonController : BaseController
    {
        //
        // GET: /Json/

        public JsonResult GetAllCities()
        {
            return Json(DataSourceManager.GetCities(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllGenders()
        {
            return Json(DataSourceManager.GetGenders(), JsonRequestBehavior.AllowGet);
        }

    }
}
