using Gnc2.Com.App_GlobalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.DB.Interfaces
{
    public interface IPromoCodeArchives : IBaseEntity<PromoCodeArchives>
    {

        [Required(ErrorMessageResourceName = "CatalogIdReq", ErrorMessageResourceType = typeof(rsrcPromoCodeArchives))]
        [Display(Name = "CatalogId", ResourceType = typeof(rsrcPromoCodeArchives))]
        int CatalogId { get; set; }

        [Required(ErrorMessageResourceName = "PromoCodeTypeIdReq", ErrorMessageResourceType = typeof(rsrcPromoCodeArchives))]
        [Display(Name = "PromoCodeTypeId", ResourceType = typeof(rsrcPromoCodeArchives))]
        int PromoCodeTypeId { get; set; }

        [Required(ErrorMessageResourceName = "PromoCodeNameReq", ErrorMessageResourceType = typeof(rsrcPromoCodeArchives))]
        [Display(Name = "PromoCodeName", ResourceType = typeof(rsrcPromoCodeArchives))]
        string PromoCodeName { get; set; }

        [Required(ErrorMessageResourceName = "CreateDateReq", ErrorMessageResourceType = typeof(rsrcPromoCodeArchives))]
        [Display(Name = "CreateDate", ResourceType = typeof(rsrcPromoCodeArchives))]
        DateTime CreateDate { get; set; }

        [Required(ErrorMessageResourceName = "UserIdReq", ErrorMessageResourceType = typeof(rsrcPromoCodeArchives))]
        [Display(Name = "UserId", ResourceType = typeof(rsrcPromoCodeArchives))]
        int UserId { get; set; }

    }
}
