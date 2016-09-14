using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gnc2.Service;
using Gnc2.Models;

namespace Gnc2.Controllers
{
    public class BannersController : BaseController
    {
        //
        // GET: /Banners/

        public PartialViewResult Default(DB.Virtual.Enums.BannerPosition Position=DB.Virtual.Enums.BannerPosition.Login)
        {
            srvBanners srvBanner = new srvBanners();

            var model = srvBanner.GetBannerPosition(Position);

            return PartialView(model);
        }

    }
}
