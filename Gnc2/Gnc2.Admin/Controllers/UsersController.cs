using Gnc2.Service;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Gnc2.Admin.App_Manager;
using Gnc2.DB;
using Gnc2.DB.Virtual;
using Gnc2.Com.Helpers;
using LIB.ExtentionMethods;
using Gnc2.Com.Helpers.UrlHelperExtensions;


namespace Gnc2.Admin.Controllers
{
    public class UsersController : BaseAuthorizedController
    {
        // GET: /Users/

        srvUsers service = new srvUsers();

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult k_jRead([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetAll().OrderBy(p => p.Name).ToDataSourceResult(request));
        }

        [ValidateInput(false)]
        public ActionResult k_jDelete([DataSourceRequest] DataSourceRequest request, Users item)
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
        public ActionResult Form(Users entity)
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


        public JsonResult GetGender()
        {
            return Json(DataSourceManager.GetGender(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDisableUser()
        {
            return Json(DataSourceManager.GetDisableUser(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUserDateProcess()
        {
            return Json(DataSourceManager.GetUserDateProcess(), JsonRequestBehavior.AllowGet);
        }



        [OutputCache(Duration = 0)]
        public ActionResult Sortable(int? UserOrderType)
        {
            if (UserOrderType == null)
                return View();
            else
            {
                ViewBag.SeletectedId = UserOrderType;

                switch (UserOrderType)
                {
                    case 1:

                        // Bu gün kayıt olan kullanıcılar
                        return View(service.GetToDayRecord(Enums.UserOrderType.GetToDayRecord));

                    case 2:

                        // Bu hafta kayıt olan kullanıcılar
                        return View(service.GetToThisWeekRecord(Enums.UserOrderType.GetToThisWeekRecord));

                    case 3:
                        // Bu ay kayıt olan kullanıcılar
                        return View(service.GetToThisMonthRecord(Enums.UserOrderType.GetToThisMonthLogin));

                    case 4:
                        // Facebook ile kayıt olan kullanıcılar.
                        return null;


                    case 5:
                        // Bu gün login olanlar kullanıcılar
                        return View(service.GetToDayLogin(Enums.UserOrderType.GetToDayLogin));
                    
                    case 6:
                        // Bu hafta login olanlar kullanıcılar
                        return View(service.GetToThisWeekRecord(Enums.UserOrderType.GetToThisWeekRecord));

                    case 7:
                        // Bu ay login olanlar kullanıcılar
                        return null;
                      
                    default:

                        break;
                }

                return View();
            }
        }

        public ActionResult control()
        {
            return View();
        }

        [HttpPost]
        public ActionResult control(string PromoCodeFileName)
        {
            var path = ((string)PathHelper.TextFiles.PathByType(PathHelper.TextFiles.Type.promocodes, PromoCodeFileName)).ToPhysical();
            System.IO.StreamReader fileq = new System.IO.StreamReader(path.ToFullPathPhysc());

           
            Context c = new Context();
            srvUsers srv = new srvUsers();
            string result = String.Empty;

            string registerOk = String.Empty;
            string registerNot = String.Empty;
            int rCountOk = 0;
            int rCountNot = 0;
            if (fileq != null)
            {
                string s = String.Empty;
                while ((s = fileq.ReadLine()) != null)
                {
                    s = s.Replace(System.Environment.NewLine, null).Replace(" ", "");
                    Users usr = srv.GetByMsisdn(s);
                    if (usr == null)
                    {
                        registerNot += s + "<br>";
                        rCountNot++;
                    }
                    else
                    {
                        registerOk += s + "<br>";
                        rCountOk++;
                    }
                }
                result = "Toplam Kullanıcı Sayısı : " + (rCountNot + rCountOk).ToString() + "<br />";
                result += "Üye Kullanıcı Sayısı : " + rCountOk.ToString() + "<br />";
                result += "Üye Olmayan Kullanıcı Sayısı : " + rCountNot.ToString() + "<br /><br />";

                result += "<div style=\"float:left;\"><b>Üye Olan Kullanıcılar</b><br /><br />" + registerOk + "</div>";
                result += "<div style=\"padding-left:200px;\"><b>Üye Olmayan Kullanıcılar</b><br /><br />" + registerNot + "</div>";

               

                string fileName = DateTime.Now.ToString().Replace("/", "").Replace(".", "").Replace("-", "").Replace(" ", "").Replace(":", "") + ".txt";
                var pathSave = ((string)PathHelper.TextFiles.PathByType(PathHelper.TextFiles.Type.promocodes, fileName)).ToPhysical();
                System.IO.File.WriteAllText(pathSave.ToFullPathPhysc(), registerOk.Replace("<br>", System.Environment.NewLine));



                result += "<br /><br /><a target=\"_blank\" href=\"" + ConfigManager.GetInstance().url_Static + pathSave.ToPhysical() + "\">Üye olan kullanıcıları .txt dosyası olarak indirmek için tıklayınız.</a>";

            }
            return PartialResult(result);
        }

    }
}

