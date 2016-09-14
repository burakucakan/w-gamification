using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gnc2.Controllers
{
    public class GlobalController : BaseController
    {
        //
        // GET: /Global/

        public PartialViewResult GncScore()
        {
            return PartialView();
        }

        public PartialViewResult GncRemaining()
        {
            return PartialView();
        }

        public PartialViewResult GncBadges()
        {
            return PartialView();
        }

        public PartialViewResult PartialError()
        {
            return PartialView();
        }

    }
}
