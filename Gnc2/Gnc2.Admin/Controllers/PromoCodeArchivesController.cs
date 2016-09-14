using Gnc2.DB;
using Gnc2.Service;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;


namespace Gnc2.Admin.Controllers
{
    public class PromoCodeArchivesController : BaseAuthorizedController
    {
        //
        // GET: /PromoCodeArchives/

        srvPromoCodeArchives service = new srvPromoCodeArchives();

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult k_jRead([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetAll().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public ActionResult k_jDelete([DataSourceRequest] DataSourceRequest request, PromoCodeArchives item)
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
        public ActionResult Form(PromoCodeArchives entity)
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
