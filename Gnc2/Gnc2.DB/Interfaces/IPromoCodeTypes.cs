using Gnc2.Com.App_GlobalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.DB.Interfaces
{
    interface IPromoCodeTypes : IBaseEntity<PromoCodeTypes>
    {

        [Required(ErrorMessageResourceName = "PromoCodeTypeNameReq", ErrorMessageResourceType = typeof(rsrcPromoCodeTypes))]
        [Display(Name = "PromoCodeTypeName", ResourceType = typeof(rsrcPromoCodeTypes))]
        string PromoCodeTypeName { get; set; }

        [Required(ErrorMessageResourceName = "PromoCodeTypeNameReq", ErrorMessageResourceType = typeof(rsrcPromoCodeTypes))]
        [Display(Name = "PromoCodeTypeName", ResourceType = typeof(rsrcPromoCodeTypes))]
        int ModifiedBy { get; set; }

    }
}
