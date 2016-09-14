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
    public class AdminUserController : BaseAuthorizedController
    {
        //
        // GET: /Admin/
        srvAdmins service = new srvAdmins();

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult k_jRead([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetAll().OrderBy(p => p.Id).ToDataSourceResult(request));
        }

        [ValidateInput(false)]
        public ActionResult k_jDelete([DataSourceRequest] DataSourceRequest request, Admins item)
        {
            if (item != null)
                service.DeleteAndCommit(item);

            return k_jRead(request);
        }

        public ActionResult Form(int? Id)
        {
            if (Id != null)
            {
                srvAdminAuths adminAuthService = new srvAdminAuths();
                ViewBag.AdminAuths = adminAuthService.GetByAdminId(Id.Value);
                var modelData = service.GetById(Id.Value);
                return View(modelData);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Form(Admins entity)
        {
            try
            {
                List<string> RequestValues = null;

                if (Request.Form["chAuth"] != null)
                    RequestValues = new List<string>(Request.Form["chAuth"].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));

                srvAdminAuths srvAdminAuths = new Service.srvAdminAuths();
                service.SaveWithPermission(entity, srvAdminAuths, RequestValues);

                return PartialResultSuccess();
            }
            catch (Exception)
            {
                return PartialResultError();
            }
        }

        public ActionResult UserSelfForm()
        {
            return View(service.GetById(session.AdminId));
        }

        [HttpPost]
        public ActionResult UserSelfForm(Admins entity)
        {
            try
            {
                entity.Id = session.AdminId;
                service.Save(entity);

                session.FirstName = entity.FirstName;
                session.LastName = entity.LastName;
                session.UserPhoto = entity.FileName;

                return PartialResultSuccess();
            }
            catch (Exception)
            {
                return PartialResultError();
            }
        }
    }
}
