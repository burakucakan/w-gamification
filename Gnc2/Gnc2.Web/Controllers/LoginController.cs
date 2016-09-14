 using System;
using System.Collections.Generic;
 using System.Globalization;
 using System.Linq;
 using System.Net;
 using System.Web;
using System.Web.Mvc;
using Gnc2.App_Manager;
using Gnc2.Models;
using Gnc2.DB;
using System.Data.Entity.Validation;
using System.Diagnostics;
using Gnc2.Service;
using Gnc2.Service.ServiceRegister;
using Gnc2.Service.ServiceUserManagement;
 using Gnc2.Ws;
 using LIB;
using Facebook;

using MvcHelper.Facebook;
using MvcHelper.Facebook.Models;

namespace Gnc2.Controllers
{
    public class LoginController : BaseController
    {
        public ActionResult SsoCompleted()
        {
            string Msisdn = GetHeaderMsisdn();
            ViewBag.Msisdn = Msisdn;

            srvUsers srv = new srvUsers();
            Users user = srv.GetByMsisdn(Msisdn);
            if (user == null)
            {
                //gnc2 kare ilk geliş
                if (session.IsFbLogin)
                {
                    //facebook üzerinden gelen user
                    return Redirect("RegisterFb");
                }
                else
                {
                    //facebookdan gelmeyen user - kayıt formu
                    return Redirect("Register");
                }
            }
            else
            {
                if (session.IsFbLogin)
                {
                    //facebooktan gelen kullanıcı
                    user.LoginDate = DateTime.Now;
                    user.FbProfileImage = session.FbUser.ProfilePicture.Data.Url;
                    user.FbId = session.FbUser.FbId;
                    user.Name = session.FbUser.FirstName;
                    user.Surname = session.FbUser.LastName;
                    user.Email = session.FbUser.Email;

                    try
                    {
                        user.BirthDate = DateTime.Parse(session.FbUser.BirthDay);
                    }
                    catch (Exception ex)
                    {
                        user.BirthDate = DateTime.Parse("01/01/1900");
                    }
                    
                    if (session.FbUser.Gender.ToLower() == "male")
                    {
                        user.Gender = 1;
                    }
                    else if(session.FbUser.Gender.ToLower() == "female")
                    {
                        user.Gender = 0;
                    }

                    srv.Save(user);

                    LogonUserModel UserModel = new LogonUserModel();
                    UserModel.Mssidn = session.LocalMsisdn;
                    UserModel.Name = user.Name;
                    UserModel.Surname = user.Surname;
                    session.LogonUser = UserModel;
                    // kullanıcı bilgileri session vs.


                    Service.ServiceSiteActivity.SiteActivityClient siteActivity = new Service.ServiceSiteActivity.SiteActivityClient();
                    Service.ServiceSiteActivity.NotifyUserLogin userInfo = new Service.ServiceSiteActivity.NotifyUserLogin();
                    userInfo.Msisdn = session.LocalMsisdn;
                    userInfo.Key = ConfigManager.GetInstance().wsk;
                    userInfo.Cid = ConfigManager.GetInstance().cid;
                    Service.ServiceSiteActivity.NotifyUserLoginResponse response = siteActivity.SiteLogin(userInfo);

                    return Redirect("LinkSocial");
                }
                else
                {
                    //facebookdan gelmeyen user - login
                    srv.UpdateLastLogin(user);

                    LogonUserModel UserModel = new LogonUserModel();
                        UserModel.Mssidn = session.LocalMsisdn;
                    UserModel.Name = user.Name;
                    UserModel.Surname = user.Surname;
                    session.LogonUser = UserModel;
                   // kullanıcı bilgileri session vs.


                    Service.ServiceSiteActivity.SiteActivityClient siteActivity = new Service.ServiceSiteActivity.SiteActivityClient();
                    Service.ServiceSiteActivity.NotifyUserLogin userInfo = new Service.ServiceSiteActivity.NotifyUserLogin();
                    userInfo.Msisdn = session.LocalMsisdn;
                    userInfo.Key = ConfigManager.GetInstance().wsk;
                    userInfo.Cid = ConfigManager.GetInstance().cid;
                    Service.ServiceSiteActivity.NotifyUserLoginResponse response = siteActivity.SiteLogin(userInfo);


                    return Redirect("LinkSocial");
                }
            }
        }

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult LoginType()
        {
            if (session.IsLogin)
            {
                return Redirect("LinkSocial");
            }
            else
            {
               return View(); 
            }
            
        }

        public ActionResult SpecialForYou()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult RegisterFb()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult RegisterFb(Users model)
        {
            model.FbProfileImage = session.FbUser.ProfilePicture.Data.Url;
            model.FbId = session.FbUser.FbId;
            model.Name = session.FbUser.FirstName;
            model.Surname = session.FbUser.LastName;
            model.Email = session.FbUser.Email;
            model.Msisdn = session.LocalMsisdn;
            
            model.LoginDate = DateTime.Now; //Giriş Tarihi
            model.CreateDate = DateTime.Now; //Kayıt Tarihi

            string userBirthDay = session.FbUser.BirthDay;
            int dateParse = userBirthDay.Split('/').Count();
            if (dateParse == 2)
            {
                string dateText = userBirthDay.Split('/')[1] + "/" + userBirthDay.Split('/')[0];
                session.FbUser.BirthDay = DateTime.Parse(dateText + "/1900").ToShortDateString();
                model.BirthDate = DateTime.Parse(session.FbUser.BirthDay);
            }
            else
            {
                //IFormatProvider prof=new CultureInfo(1055);
                string dateText = userBirthDay.Split('/')[1] + "/" + userBirthDay.Split('/')[0] + "/" +
                                  userBirthDay.Split('/')[2];

                session.FbUser.BirthDay = DateTime.Parse(dateText).ToShortDateString();
                model.BirthDate = DateTime.Parse(session.FbUser.BirthDay);
            }

            /*try
            {
                model.BirthDate = DateTime.Parse(session.FbUser.BirthDay);
            }
            catch (Exception ex)
            {
                model.BirthDate = DateTime.Parse("01/01/1900");
            }*/

            if (session.FbUser.Gender.ToLower() == "male")
            {
                model.Gender = 1;
            }
            else if (session.FbUser.Gender.ToLower() == "female")
            {
                model.Gender = 0;
            }

            Service.srvUsers srv = new Service.srvUsers();
            srv.Save(model);
            
            //site activity gigya
            Service.ServiceSiteActivity.SiteActivityClient siteActivity = new Service.ServiceSiteActivity.SiteActivityClient();
            Service.ServiceSiteActivity.NotifyUserLogin userInfo = new Service.ServiceSiteActivity.NotifyUserLogin();
            userInfo.Msisdn = session.LocalMsisdn;
            userInfo.Key = ConfigManager.GetInstance().wsk;
            userInfo.Cid = ConfigManager.GetInstance().cid;
            Service.ServiceSiteActivity.NotifyUserLoginResponse response = siteActivity.SiteRegister(userInfo);

            //session
            session.IsLogin = true;
            session.IsFbLogin = true;
            session.LogonUser.Mssidn = session.LocalMsisdn;
            session.LogonUser.Name = model.Name;
            session.LogonUser.Surname = model.Surname;

            //turkcell veri işleme izni
            Service.ServiceRegister.PermissionQueryServiceClient sqq = new PermissionQueryServiceClient();
            if (model.Ispermissions == true)
            {
                sqq.WriteServicePermission(model.Msisdn, Permission.PermissionGranted);
            }
            else
            {
                sqq.WriteServicePermission(model.Msisdn, Permission.PermissionDenied);
            }
            return RedirectToAction("LinkSocial");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Register(Users model)
        {
            //gnc2 db kayıt
            model.Msisdn = session.LocalMsisdn;
            model.ProfileImage = "TurkcellGnc2_6138_forfdmages.jpg"; //default foto - upload aktif hale gelecek.
            model.LoginDate=DateTime.Now; //Giriş Tarihi
            model.CreateDate = DateTime.Now; //Kayıt Tarihi

            Service.srvUsers srv = new Service.srvUsers();
            srv.Save(model);

            //site activity gigya
            Service.ServiceSiteActivity.SiteActivityClient siteActivity = new Service.ServiceSiteActivity.SiteActivityClient();
            Service.ServiceSiteActivity.NotifyUserLogin userInfo = new Service.ServiceSiteActivity.NotifyUserLogin();
            userInfo.Msisdn = session.LocalMsisdn;
            userInfo.Key = ConfigManager.GetInstance().wsk;
            userInfo.Cid = ConfigManager.GetInstance().cid;
            Service.ServiceSiteActivity.NotifyUserLoginResponse response = siteActivity.SiteRegister(userInfo);

            //session
            session.IsLogin = true;
            session.IsFbLogin = false;
            session.LogonUser.Mssidn = session.LocalMsisdn;
            session.LogonUser.Name = model.Name;
            session.LogonUser.Surname = model.Surname;

            //turkcell veri işleme izni
            Service.ServiceRegister.PermissionQueryServiceClient sqq = new PermissionQueryServiceClient();
            if (model.Ispermissions == true)
    	    {
                sqq.WriteServicePermission(model.Msisdn, Permission.PermissionGranted);
	        }
            else
            {
                sqq.WriteServicePermission(model.Msisdn, Permission.PermissionDenied);
            }
            return RedirectToAction("LinkSocial");
        }


        [ValidateInput(false)]
        public ActionResult RegisterEdit(Gnc2.DB.Users model)
        {

            srvUsers srv = new srvUsers();
            srv.Save(model);
            

            Service.ServiceRegister.PermissionQueryServiceClient sqq = new PermissionQueryServiceClient();

            if (model.Ispermissions == true)
            {
                sqq.WriteServicePermission(model.Msisdn, Permission.PermissionGranted);
            }

            else
            {
                sqq.WriteServicePermission(model.Msisdn, Permission.PermissionDenied);
            }

            return RedirectToAction("LinkSocial");

        }

        public ActionResult LinkSocial()
        {
            return View();
        }


        public ActionResult SsoResult()
        {
            
            #region :: Local Fake Logic ::
            if (LIB.Util.IsLocal() && session.LocalMsisdn == String.Empty && Request.QueryString["LocalMsisdn"] == null)
                Response.Redirect(config.LocalSsoUrl);

            if ((LIB.Util.IsLocal()) && (Request.QueryString["LocalMsisdn"] != null))
                session.LocalMsisdn = Request.QueryString["LocalMsisdn"].ToString();
            #endregion

            return View();
        }
        
        public PartialViewResult DataProcessing()
        {
            return PartialView();
        }

      
        public PartialViewResult TermsofUse()
        {
            return PartialView();
        }


        [HttpPost]
        public JsonResult FbLogin(string JsonData)
        {
            try
            {
                var UserFbData = FacebookUtil.FetchingData(JsonData);
             
                PrepareUser(UserFbData);

                session.IsFbLogin = true;

                return Json(new { result = "1" }, "text/plain");
            }
            catch (Exception ex)
            {

                return Json(new { result = ex.Message + " inner ex: " + ex.InnerException }, "text/plain");
            }


        }

        private void PrepareUser(FacebookUser FbData)
        {
            FacebookUser FbUser = new FacebookUser();
            FbUser.FbId = FbData.FbId;
            FbUser.Name = FbData.Name;
            FbUser.FirstName = FbData.FirstName;
            FbUser.LastName = FbData.LastName;
            FbUser.Email = FbData.Email;
            FbUser.Gender = FbData.Gender;
            FbUser.ProfilePicture= FbData.ProfilePicture;
            FbUser.BirthDay = FbData.BirthDay;

            session.IsLogin = true;
            session.IsFbLogin = true;

            session.FbUser = FbUser;

            srvUsers srv = new srvUsers();
            Users user = srv.GetByFbId(FbData.FbId);
            LogonUserModel UserModel=new LogonUserModel();
            if (user != null)
            {
                UserModel.Mssidn= user.Msisdn;
                session.LocalMsisdn = user.Msisdn;

                Service.ServiceSiteActivity.SiteActivityClient siteActivity = new Service.ServiceSiteActivity.SiteActivityClient();
                Service.ServiceSiteActivity.NotifyUserLogin userInfo = new Service.ServiceSiteActivity.NotifyUserLogin();
                userInfo.Msisdn = user.Msisdn;
                userInfo.Key = ConfigManager.GetInstance().wsk;
                userInfo.Cid = ConfigManager.GetInstance().cid;
                Service.ServiceSiteActivity.NotifyUserLoginResponse response = siteActivity.SiteLogin(userInfo);
            }
            UserModel.Name = FbData.FirstName;
            UserModel.Surname = FbData.LastName;
            session.LogonUser = UserModel;
            //session.FbUser = (new Serialize()).SerializeObject(FbUser);
        }

    }
}