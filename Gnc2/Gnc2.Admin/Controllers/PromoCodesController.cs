using Gnc2.DB;
using Gnc2.Service;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Gnc2.Admin.Models;

namespace Gnc2.Admin.Controllers
{

   
    public class PromoCodesController : BaseAuthorizedController
    {

        srvPromoCodes service = new srvPromoCodes();


        public void ddl()
        {
            var query = service.GetPromoCodeType().Select(a => new { a.Id, a.PromoCodeTypeName });
            ViewBag.promocode = new SelectList(query.AsEnumerable(), "Id", "PromoCodeTypeName");
        }


        public ActionResult Default()
        {
            return View();
        }

        public JsonResult k_jRead([DataSourceRequest] DataSourceRequest request)
        {
            Context c = new Context();

            IEnumerable<PromoCodes> f = new srvPromoCodes().GetAllIncludingInActive();

            IList<PromoCodeBounded> p = new List<PromoCodeBounded>();
            PromoCodeBounded pc;

            foreach (var item in f.ToList())
            {
                pc = new PromoCodeBounded();
                pc.Id = item.Id;
                pc.PromoCodeName = item.PromoCodeName;
                pc.CatalogName = item.Catalogs.CatalogName;
                p.Add(pc);
            }
            return Json(p.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        //var data = new srvPromoCodes().GetAllIncludingInActive();

        //var collection = data.Select(x => new
        //{
        //    id = x.Id,
        //    PromoCodeName = x.PromoCodeName,
        //    CatalogName = x.Catalogs.CatalogName
        //});
        //return Json(collection , JsonRequestBehavior.AllowGet);


        //public JsonResult k_jRead([DataSourceRequest] DataSourceRequest request)
        //{
        //    Context c = new Context();

        //    var promo = from s in c.PromoCodes select new { s.PromoCodeName, s.Categories.CatalogName, s.Id };

        //    return Json(promo.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        //}

        //   public JsonResult GetStudentJson()
        //   {
        //            db.Configuration.ProxyCreationEnabled = false;
        //            var students = db.Students;
        //            return Json(students, JsonRequestBehavior.AllowGet);
        //   }
        //The Out Put is Look like bellow
        //  [{"StudentID":1,"StudentName":"John","StandardId":1,"Standard":null,
        //     "StudentAddress":null,"Courses":[]}]



        public ActionResult Form(int? Id)
        {
            ddl();

            if (Id != null)
            {

                var modelData = service.GetById(Id.Value);
                return View(modelData);
            }

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Form(PromoCodes entity)
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


        public ActionResult test()
        {
            Context c = new Context();

            var query = c.PromoCodes.ToList();
            return View(query);
        }

    }
}





