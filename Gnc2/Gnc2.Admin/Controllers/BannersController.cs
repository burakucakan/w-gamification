using Gnc2.Service;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Gnc2.DB;
using Gnc2.DB.Virtual;
using Gnc2.Com.General;
using Gnc2.Admin.App_Manager;
namespace Gnc2.Admin.Controllers
{
    public class BannersController : BaseAuthorizedController
    {
        //
        // GET: /Banners/

        srvBanners service = new srvBanners();

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult k_jRead([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetAll().OrderBy(p => p.Title).ToDataSourceResult(request));
        }

        [ValidateInput(false)]
        public ActionResult k_jDelete([DataSourceRequest] DataSourceRequest request, Banners item)
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
        public ActionResult Form(Banners entity)
        {
            try
            {
                service.Save(entity, true);
                return PartialResultSuccess();
            }
            catch (Exception)
            {
                return PartialResultError();
            }
        }

        public JsonResult GetBannerTypes()
        {
            return Json(DataSourceManager.GetBannerTypes(), JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 0)]
        public ActionResult Sortable(int? PositionCode)
        {
            if (PositionCode == null)
                return View();
            else
            {
                ViewBag.SeletectedId = PositionCode;
                return View(service.GetAllPublishedByType((Enums.BannerPosition)PositionCode));
            }
        }

        public JsonResult UpdateOrders(string Values)
        {
            string[] str = Values.Split(',');

            try
            {
                var i = 0;
                foreach (var item in str)
                {
                    var entity = service.GetById(int.Parse(item));
                    entity.Order = i.ToString().PadLeft(GlobalVars.OrderLength, '0');
                    service.Save(entity);

                    i++;
                }

                service.Commit();
            }
            catch (Exception)
            { }
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }

    }
}