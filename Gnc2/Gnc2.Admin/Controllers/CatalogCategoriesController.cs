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
    public class CatalogCategoriesController : BaseAuthorizedController
    {

        srvCatalogCategories service = new srvCatalogCategories();

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult k_jRead([DataSourceRequest] DataSourceRequest request)
        {

            Context c = new Context();

            IEnumerable<CatalogCategories> f = new srvCatalogCategories().GetAllIncludingInActive();

            IList<CatalogCategoriesBounded> p = new List<CatalogCategoriesBounded>();
            CatalogCategoriesBounded pc;

            foreach (var item in f.ToList())
            {
                pc = new CatalogCategoriesBounded();
                pc.Id = item.Id;
                pc.CategoryName = item.CategoryName;
                p.Add(pc);
            }
            return Json(p.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

     
        }


        [ValidateInput(false)]
        public ActionResult k_jDelete([DataSourceRequest] DataSourceRequest request, CatalogCategories item)
        {
            if (item != null)
            service.DeleteAndCommit(item);

            return k_jRead(request);
        }

        public ActionResult Form(int? Id)
        {
            if (Id != null)
            {
                var modelData = service.GetById(Id.Value);
                return View(modelData);
            }

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Form(CatalogCategories entity)
        {
            try
            {
                service.Save(entity, true, true);
                return PartialResultSuccess();
            }
            catch (Exception)
            {
                return PartialResultError();
            }
        }

    }
}
