using Gnc2.DB;
using Gnc2.Service;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Gnc2.Com.Helpers.UrlHelperExtensions;
using Gnc2.Admin.App_Manager;
using Gnc2.DB;
using Gnc2.DB.Virtual;
using Gnc2.Com.Helpers;
using LIB.ExtentionMethods;

namespace Gnc2.Admin.Controllers
{
    public class CampaignsController : BaseAuthorizedController
    {
         // GET: /Campaigns/

        srvCampaigns service = new srvCampaigns();
        srvUserCampaigns serviceCampaigns = new srvUserCampaigns();

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult k_jRead([DataSourceRequest] DataSourceRequest request)
        {
            return Json(service.GetAll().OrderBy(p => p.Title).ToDataSourceResult(request));
        }

        [ValidateInput(false)]
        public ActionResult k_jDelete([DataSourceRequest] DataSourceRequest request, Campaigns item)
        {
            if (item != null)

                service.DeleteAndCommit(item);


            return k_jRead(request);
        }


        public ActionResult Form(int? Id)
        {

            if (Id != null)
            {
                var modelData = service.GetById(Id.Value);
                return View(modelData);
            }

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Form(Campaigns entity, string CampaignsTextFile)
        {
            try
            {
                int campaignId = service.Save(entity, true, true);

                if (entity.IsUserCampaigns)
                {
                    if (CampaignsTextFile != null)
                    {
                        var path = ((string)PathHelper.TextFiles.PathByType(PathHelper.TextFiles.Type.campaigns, CampaignsTextFile)).ToPhysical();
                        System.IO.StreamReader fileq = new System.IO.StreamReader(path.ToFullPathPhysc());
                        srvUsers srv = new srvUsers();
                        if (fileq != null)
                        {
                            string s = String.Empty;
                            while ((s = fileq.ReadLine()) != null)
                            {
                                s = s.Replace(System.Environment.NewLine, null).Replace(" ", "");
                                Users usr = srv.GetByMsisdn(s);
                                if (usr != null)
                                {
                                    UserCampaigns userCampaign = new UserCampaigns();
                                    userCampaign.CampaignId = campaignId;
                                    userCampaign.UserId = usr.Id;
                                    userCampaign.IsActive = true;
                                    userCampaign.IsDeleted = false;
                                    serviceCampaigns.Save(userCampaign, true, true);
                                    //kayıt yap
                                }
                            }
                        }
                    }
                }

                return PartialResultSuccess();
            }
            catch (Exception)
            {
                return PartialResultError();
            }
        }
    }
}
