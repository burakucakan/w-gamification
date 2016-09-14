using Gnc2.Service;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Gnc2.DB;
using Gnc2.Admin.Models;

namespace Gnc2.Admin.Controllers
{
    public class CatalogTypeController : Controller
    {
        // GET: /CatalogType/

      //  srvCatalogType service = new srvCatalogType();

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult k_jRead([DataSourceRequest] DataSourceRequest request)
        {
            IList<CatalogTypeBounded> p = new List<CatalogTypeBounded>();
            /*
            Context c = new Context();

            IEnumerable<CatalogType> f = new srvCatalogType().GetCatalogType();

            IList<CatalogTypeBounded> p = new List<CatalogTypeBounded>();
            CatalogTypeBounded pc;

            foreach (var item in f.ToList())
            {
                pc = new CatalogTypeBounded();
                pc.Id = item.Id;
                pc.CatalogTypeName = item.CatalogTypeName;

                p.Add(pc);
            }*/
            return Json(p.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

    }
}
