using Gnc2.DB;
using Gnc2.Service;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Gnc2.Admin;
using Gnc2.Admin.Models;
using Gnc2.DB.Virtual;
using Gnc2.Admin.App_Manager;

namespace Gnc2.Admin.Controllers
{
    public class CatalogsController : BaseAuthorizedController
    {
        // GET: /Catalogs/

        srvCatalogs service = new srvCatalogs();
        srvPromoCodes srvPromoCodes = new srvPromoCodes();

        public void ddl()
        {
            var querycategory = service.GetCatalogCategories().Select(a => new { a.Id, a.CategoryName });
            ViewBag.category = new SelectList(querycategory.AsEnumerable(), "Id", "CategoryName");

            var querytype = service.GetModulTypes().Select(a => new { a.Id, a.CatalogTypeName });
            ViewBag.type = new SelectList(querytype.AsEnumerable(), "Id", "CatalogTypeName");

            var queryPromoCodes = srvPromoCodes.GetPromoCodeType().Select(a => new { a.Id, a.PromoCodeTypeName });
            ViewBag.Promocode = new SelectList(queryPromoCodes.AsEnumerable(), "Id", "PromoCodeTypeName");
        }

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult k_jRead([DataSourceRequest] DataSourceRequest request)
        {

            Context c = new Context();

            IEnumerable<Catalogs> f = new srvCatalogs().GetAllIncludingInActive();

            IList<CatalogBounded> p = new List<CatalogBounded>();
            CatalogBounded pc;

            foreach (var item in f.ToList())
            {
                pc = new CatalogBounded();
                pc.Id = item.Id;
                pc.Header = item.Header;
                pc.CatalogFeautures = item.CatalogFeatures;
                pc.CatalogCondition = item.CatalogCondition;
                pc.CatalogEndDate = item.CatalogEndDate;
                pc.CatalogImage = item.CatalogImage;
                pc.CatalogName = item.CatalogName;
                pc.CatalogPoint = item.CatalogPoint;
                pc.CatalogStartDate = item.CatalogStartDate;
                pc.IsActive = item.IsActive;
                pc.IsDeleted = item.IsDeleted;
                try
                {
                    pc.CatalogCategoriesName = item.CatalogCategories.CategoryName;
                }
                catch (Exception ex)
                {
                    pc.CatalogCategoriesName = "";
                }

                p.Add(pc);
            }
            return Json(p.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public ActionResult k_jDelete([DataSourceRequest] DataSourceRequest request, Catalogs item)
        {
            if (item != null)
                service.DeleteAndCommit(item);

            return k_jRead(request);
        }

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
        public ActionResult Form(Catalogs entity)
        {
            try
            {
                int _catalogId = 0;
                ddl();

                _catalogId = service.Save(entity, true, true);

                //srvPromoCodes.SaveMultipleCodes(entity.

                return PartialResultSuccess();
            }
            catch (Exception)
            {
                return PartialResultError();
            }
        }

        [OutputCache(Duration = 0)]
        public ActionResult Sortable(int? OrderType)
        {
            if (OrderType == null)
                return View();
            else
            {
                ViewBag.SeletectedId = OrderType;

                switch (OrderType)
                {
                    case 1:

                        // Son Eklenen 100 Ürün
                        return View(service.GetToLast100Catalog(Enums.CatalogOrderType.CatalogOrderDateTop));

                    case 2:

                        // En Yüksek Paunlı 100 Ürün
                        return View(service.GetToLast100TopPoint(Enums.CatalogOrderType.CatalogOrderDateTop));

                    case 3:
                        // En Düşük Puanlı 100 Ürün
                        return View(service.GetToLast100DownPoint(Enums.CatalogOrderType.CatalogOrderDateTop));

                    case 4:
                        // Süresi Geçmiş Ürünler
                        return View(service.GetToEndDateCatalog(Enums.CatalogOrderType.CatalogOrderDateTop));
                    case 5:
                        // Stoğu En Fazla Olan Ürünler
                        return View(service.GetToEndDateCatalog(Enums.CatalogOrderType.CatalogOrderDateTop));

                    case 6:
                        // Stoğu Tükenen Ürünler
                        return View(service.GetAllUnUseCatalog(Enums.CatalogOrderType.CatalogOrderDateTop));
                        
                    case 7:
                        // Kullanımda olmayan ürünler
                        return View(service.GetAllUnUseCatalog(Enums.CatalogOrderType.CatalogOrderDateTop));


                    default:

                        break;
                }

                return View();
            }
        }

        public PartialViewResult TextFileUpload()
        {
            return PartialView();
        }

        public JsonResult GetCatalogProcess()
        {
            return Json(DataSourceManager.GetCatelogProcess(), JsonRequestBehavior.AllowGet);
        }


        public void PromoCodeSave()
        {
            // txt dosyasındaki satırları (promo kodları) db'ye kayıt edelim.


            //string dosyaadi = ViewBag.savedFileName;

            //System.IO.StreamReader fileq = new System.IO.StreamReader(FullTextPath());

            //Context c = new Context();
            //if (fileq != null)
            //{
            //    string s = String.Empty;
            //    while ((s = fileq.ReadLine()) != null)
            //    {
            //        Code kod = new Code();

            //        s = s.Replace(System.Environment.NewLine, null).Replace(" ","");

            //        kod.CodeName = s;

            //        if (s.Length > 1)
            //        {

            //            c.Code.Add(kod);
            //        }
            //    }

            //    c.SaveChanges();

            //}
        
        
        }


        //public JsonResult UpdateOrders(string Values)
        //{
        //    string[] str = Values.Split(',');

        //    try
        //    {
        //        var i = 0;
        //        foreach (var item in str)
        //        {
        //            var entity = service.GetById(int.Parse(item));
        //            entity.Order = i.ToString().PadLeft(GlobalVars.OrderLength, '0');
        //            service.Save(entity);

        //            i++;
        //        }

        //        service.Commit();
        //    }
        //    catch (Exception)
        //    { }
        //    return Json(new { }, JsonRequestBehavior.AllowGet);
        //}

    }
}
