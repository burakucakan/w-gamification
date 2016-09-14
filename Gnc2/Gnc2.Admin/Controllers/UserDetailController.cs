using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gnc2.Service;


namespace Gnc2.Admin.Controllers
{
    public class UserDetailController : BaseAuthorizedController
    {
        // GET: /GsmSummary/

        public string ServiceKey = ConfigurationManager.AppSettings["wsk"].ToString();


        public ActionResult Default(string Msisdn)
        {
            return View();
        }

        public ActionResult UserPoint(string Msisdn)
        {
            srvQuery service = new srvQuery();

            var result = service.GetUserPoints(ServiceKey, Msisdn);

            return PartialView(result);

        }

        public ActionResult CurrentPoint(string Msisdn)
        {
            srvGameMechanics service = new srvGameMechanics();
            var result = service.RedeemPoint(ServiceKey, Msisdn);
            return PartialView(result);

        }

        public ActionResult UserBadge(string Msisdn)
        {
            srvBadge service = new srvBadge();
            var result = service.GetUserBadgeModel(ServiceKey, Msisdn);
            return PartialView(result);
        }

        public ActionResult GetAllBadge()
        {
            srvBadge service = new srvBadge();
            var result = service.GetBadgeModel(ServiceKey);
            return PartialView(result);
        }

        public ActionResult GetChallenge(string Msisdn)
        {
            srvGameMechanics service = new srvGameMechanics();
            var result = service.GetChallengeConfig(ServiceKey, Msisdn);
            return PartialView(result);
        }
    }
}
