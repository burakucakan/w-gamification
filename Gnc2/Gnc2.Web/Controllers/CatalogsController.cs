using Gnc2.App_Manager;
using Gnc2.DB;
using Gnc2.Models;
using Gnc2.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gnc2.Controllers
{
    public class CatalogsController : BaseController
    {
        //
        // GET: /Catalogs/

        public ActionResult Default(int? Id)
        {
            if (Id != null)
                ViewBag.CatalogCategoriesId = Id.ToString();
            return View();
        }

        public ActionResult Detail(int Id)
        {
            if (Id > 0)
            {
                srvCatalogs service = new srvCatalogs();
                var modelData = service.GetById(Id);
                return View(modelData);
            }

            return View();
        }

        public JsonResult GetAllCatalogCategories()
        {
            Context c = new Context();

            IEnumerable<CatalogCategories> catalogCategories = new srvCatalogCategories().GetAllIncludingInActive();
            IList<CatalogCategoriesBounded> catalogCategoriesBounded = new List<CatalogCategoriesBounded>();
            CatalogCategoriesBounded ccb;

            foreach (var item in catalogCategories.ToList())
            {
                ccb = new CatalogCategoriesBounded();
                ccb.Id = item.Id;
                ccb.CategoryName = item.CategoryName;
                catalogCategoriesBounded.Add(ccb);
            }
            return Json(catalogCategoriesBounded, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCategories()
        {
            //srvCatalogs service = new srvCatalogs();
            //return Json(service.GetAll(), JsonRequestBehavior.AllowGet);

            Context c = new Context();

            IEnumerable<Catalogs> catalogs = new srvCatalogs().GetAllIncludingInActive();

            IList<CatalogBounded> catalogBounded = new List<CatalogBounded>();
            CatalogBounded cb;

            foreach (var item in catalogs.ToList())
            {
                cb = new CatalogBounded();
                cb.Id = item.Id;
                cb.Header = item.Header;
                cb.CatalogFeautures = item.CatalogFeatures;
                cb.CatalogCondition = item.CatalogCondition;
                cb.CatalogEndDate = item.CatalogEndDate;
                cb.CatalogImage = item.CatalogImage;
                cb.CatalogName = item.CatalogName;
                cb.CatalogPoint = item.CatalogPoint;
                cb.CatalogStartDate = item.CatalogStartDate;
                cb.IsActive = item.IsActive;
                cb.IsDeleted = item.IsDeleted;
                cb.CatalogCategoriesName = item.CatalogCategories.CategoryName;
                cb.CatalogCategoriesId = item.CatalogCategories.Id;

                catalogBounded.Add(cb);
            }
            return Json(catalogBounded, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOrderFilters()
        {
            return Json(DataSourceManager.GetCatalogOrderFilters(), JsonRequestBehavior.AllowGet);
        }

        public static T ParseJsonObject<T>(string json) where T : class, new()
        {
            JObject jobject = JObject.Parse(json);
            return JsonConvert.DeserializeObject<T>(jobject.ToString());
        }
        public static List<T> ParseJsonObjectList<T>(string json) where T : class, new()
        {
            JObject jobject = JObject.Parse(json);
            return JsonConvert.DeserializeObject<List<T>>(jobject.ToString());
        }



    }
}
