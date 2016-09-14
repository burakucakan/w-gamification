using Gnc2.Com.App_GlobalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.DB
{
    public interface IBanners : IBaseEntity<Banners>
    {
        IEnumerable<Banners> GetBannerByPositionCode(Virtual.Enums.BannerPosition Position);

        [Required(ErrorMessageResourceName = "FileNameReq", ErrorMessageResourceType = typeof(rsrcBanners))]
        [Display(Name = "FileName", ResourceType = typeof(rsrcBanners))]
        string FileName { get; set; }

        [Required(ErrorMessageResourceName = "TitleReq", ErrorMessageResourceType = typeof(rsrcBanners))]
        [Display(Name = "Title", ResourceType = typeof(rsrcBanners))]
        string Title { get; set; }

        [Display(Name = "URL", ResourceType = typeof(rsrcBanners))]
        string URL { get; set; }

        [Required(ErrorMessageResourceName = "StartDateReq", ErrorMessageResourceType = typeof(rsrcBanners))]
        [Display(Name = "StartDate", ResourceType = typeof(rsrcBanners))]
        DateTime StartDate { get; set; }

        [Required(ErrorMessageResourceName = "EndDateReq", ErrorMessageResourceType = typeof(rsrcBanners))]
        [Display(Name = "EndDate", ResourceType = typeof(rsrcBanners))]
        string EndDate { get; set; }

        [Display(Name = "Order", ResourceType = typeof(rsrcBanners))]
        string Order { get; set; }

        [Display(Name = "WindowTypeCode", ResourceType = typeof(rsrcBanners))]
        int WindowTypeCode { get; set; }

        [Required(ErrorMessageResourceName = "PositionCodeReq", ErrorMessageResourceType = typeof(rsrcBanners))]
        [Display(Name = "PositionCode", ResourceType = typeof(rsrcBanners))]
        int PositionCode { get; set; }


    }
}