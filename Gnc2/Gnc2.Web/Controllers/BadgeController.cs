using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gnc2.Controllers
{
    public class BadgeController : BaseController
    {




        public PartialViewResult MainBadge()
        {
            //Gnc2.Service.ServicesBadge.BadgeClient sBadge = new Gnc2.Service.ServicesBadge.BadgeClient();

            //return PartialView(sBadge.GetNRandom(5, "A4B38CCC-FDC4-4413-B6F2-085806B327E5"));
            return PartialView();
        }

        public PartialViewResult MyBadges()
        {
            return PartialView();
        }

        //public PartialViewResult UserBadge()
        //{
        //    string MsIsdn = "3e37f6bf-4195-4d8e-ab7d-d6d67e13302c";

        //    Gnc2.Service.ServicesBadge.BadgeClient sBadge = new Gnc2.Service.ServicesBadge.BadgeClient();

        //    var rq = sBadge.GetUserBadge(MsIsdn, "A4B38CCC-FDC4-4413-B6F2-085806B327E5");

        //    if (rq != null)
        //    {
        //        return PartialView(sBadge.GetUserBadge(MsIsdn, "A4B38CCC-FDC4-4413-B6F2-085806B327E5"));
        //    }

        //    else
        //    {
        //        return PartialView(sBadge.GetUserBadge(MsIsdn, "A4B38CCC-FDC4-4413-B6F2-085806B327E5"));
        //    }
        //}
    }
}
