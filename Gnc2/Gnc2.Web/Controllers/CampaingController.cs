using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gnc2.Service;
using Gnc2.Models;

namespace Gnc2.Controllers
{
    public class CampaingController : BaseController
    {
        //
        // GET: /Campaing/

        public PartialViewResult HomePageCampaing()
        {
            return PartialView();
        }

        public PartialViewResult Campaing()
        {
            srvCampaigns srvCampaign = new srvCampaigns();

          //  var model = srvCampaign.GetBannerPosition(Position);

            return PartialView();
        }

    }
}
