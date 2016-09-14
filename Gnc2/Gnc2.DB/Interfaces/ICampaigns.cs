using Gnc2.Com.App_GlobalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.DB
{
    public interface ICampaigns: IBaseEntity<Campaigns>
    {
        [Required(ErrorMessageResourceName = "TitleReq", ErrorMessageResourceType = typeof(rsrcCampaigns))]
        [Display(Name = "Title", ResourceType = typeof(rsrcCampaigns))]
        string Title { get; set; }

        [Required(ErrorMessageResourceName = "TitleReq", ErrorMessageResourceType = typeof(rsrcCampaigns))]
        [Display(Name = "Image", ResourceType = typeof(rsrcCampaigns))]
        string Image { get; set; }

        [Required(ErrorMessageResourceName = "TitleReq", ErrorMessageResourceType = typeof(rsrcCampaigns))]
        [Display(Name = "Header", ResourceType = typeof(rsrcCampaigns))]
        string Header { get; set; }

        [Required(ErrorMessageResourceName = "TitleReq", ErrorMessageResourceType = typeof(rsrcCampaigns))]
        [Display(Name = "Content", ResourceType = typeof(rsrcCampaigns))]
        string Content { get; set; }

        [Display(Name = "ExternalUrl", ResourceType = typeof(rsrcCampaigns))]
        string ExternalUrl { get; set; }

        [Display(Name = "IsUserCampaigns", ResourceType = typeof(rsrcCampaigns))]
        bool IsUserCampaigns { get; set; }

    }
}
