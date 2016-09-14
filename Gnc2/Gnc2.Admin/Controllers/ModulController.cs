using Gnc2.Admin.Models;
using Gnc2.Com.General;
using Gnc2.DB;
using Gnc2.DB.Virtual;
using Gnc2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;


namespace Gnc2.Admin.Controllers
{
    public class ModulController : BaseController
    {
        // GET: /Modul/

        srvModuls service = new srvModuls();

        public ActionResult Default(IEnumerable<AdminAuths> AdminAuths = null)
        {
            if (AdminAuths != null)
                ViewBag.AdminAuths = AdminAuths;

            return PartialView(service.GetListForAdmin());
        
        }

        public ActionResult PanelMenu()
        {
            return PartialView(session.Permissions);
        }

        public ActionResult PanelMenuGroup(string groupDesc, Enums.AdminModulGroup AdminModulGroupTr)
        {
            PanelMenuGroupModel model = new PanelMenuGroupModel();
            model.GroupDescription = groupDesc;
            model.List = session.Permissions.ToList();
            return PartialView(model);
        }

    }
}
