using Gnc2.Com.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gnc2.Controllers
{
    public class NewsFeedController : BaseController
    {
        //
        // GET: /NewsFeed/

        public PartialViewResult Default()
        {
            return PartialView();
        }

        public PartialViewResult DefaultContainer()
        {
            return PartialView();
        }

        public JsonResult GetNewsFeed()
        {
            var model =new 
            {
                image = PathHelper.UrlStatic + "/images/_offline/users/nusret.jpg",
                name = "Nusret S.",
                desc = "<u>Kahve Fırsatını</u> yakaladı.",
                score = "+150"
            };

            

            return Json(model, JsonRequestBehavior.AllowGet);
        }

    }
}
