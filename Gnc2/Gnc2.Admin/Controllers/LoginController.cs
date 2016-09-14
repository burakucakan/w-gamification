using Gnc2.Admin.App_Manager;
using Gnc2.Admin.Models;
using Gnc2.Com.General;
using Gnc2.DB;
using Gnc2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gnc2.Admin.Controllers
{
    public class LoginController : BaseController
    {
        //
        // GET: /Login/

        public ActionResult Default()
        {
            if (config.AutoLogin) return AutoLogin();

            return HasCookie() ? ViewMain() : View();
        }

        [HttpPost]
        public ActionResult Default(Admins model, bool RememberMe)
        {
            srvAdmins srv = new srvAdmins();
            model = srv.GetAuth(model.Username, model.Password);
            if (model != null)
            {
                Logon(model,RememberMe);
                return ViewMain();
            }
            ViewBag.LoginFailed = true;
            return View();
        }

        public ActionResult Exit()
        {
            session.Destroy();
            CookieManager Cookie = new CookieManager();
            Cookie.Delete(CookieManager.CookieType.AdminId);
            return RedirectToAction("Default");
        }


        #region Private
        private ActionResult AutoLogin()
        {
            srvAdmins srv = new srvAdmins();
            Admins entity = srv.GetById(Convert.ToInt32(config.AdminId));
            Logon(entity,true);
            return ViewMain();
        }

        private void Logon(Admins entity, bool RememberMe)
        {
            FillSession(entity);
            if (RememberMe)
                SetCookie();
        }

        private void SetCookie()
        {
            CookieManager cookie = new CookieManager();
            cookie.Write(CookieManager.CookieType.AdminId, session.AdminId);
        }

        private void FillSession(Admins entity)
        {
            session.IsLogin = true;
            session.AdminId = entity.Id;
            session.Username = entity.Username;
            session.FirstName = entity.FirstName;
            session.LastName = entity.LastName;
            session.UserPhoto = entity.FileName;
            session.FullAuth = entity.FullAuth;

            SetStatics();

            srvModuls modulService = new srvModuls();
            bool fullAuth = entity.FullAuth;
           
            
            //List<PanelMenuModel> listPanelMenuModel=new List<PanelMenuModel>();
            //if (fullAuth==true)
            //    modulService.GetPanelMenuList();
            //else
            //    modulService.GetAdminPermissions(entity.Id);

            //session.Permissions = listPanelMenuModel;
        }

        private void SetStatics()
        {
            GlobalVars.CurrAdminId = session.AdminId;
        }

        private bool HasCookie()
        {
            CookieManager Cookie = new CookieManager();
            int AdminId;
            if (int.TryParse(Cookie.Read(CookieManager.CookieType.AdminId), out AdminId))
            {
               // FillSession(entity);
                SetCookie();
                return true;
            }
            return false;
        }
        #endregion        

    }
}
