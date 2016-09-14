using Gnc2.Com.App_GlobalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Gnc2.DB.Interfaces
{
    public interface IPromoCodes : IBaseEntity<PromoCodes>
    {
        [Required(ErrorMessageResourceName = "PromoCodeNameReq", ErrorMessageResourceType = typeof(rsrcPromoCodes))]
        [Display(Name = "PromoCodeName", ResourceType = typeof(rsrcPromoCodes))]
        string PromoCodeName { get; set; }
       

        [Required(ErrorMessageResourceName = "PromoCodeTypeIdReq", ErrorMessageResourceType = typeof(rsrcPromoCodeTypes))]
        [Display(Name = "PromoCodeTypeId", ResourceType = typeof(rsrcPromoCodes))]
        int PromoCodeTypeId { get; set; }

        [Required(ErrorMessageResourceName = "CatalogsIdReq", ErrorMessageResourceType = typeof(rsrcPromoCodes))]
        [Display(Name = "CatalogsId", ResourceType = typeof(rsrcPromoCodes))]
        int CatalogsId { get; set; }

        


    }
}
