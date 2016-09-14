using Gnc2.Com.App_GlobalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.DB.Interfaces
{
    interface IModulTypes : IBaseEntity<CatalogType>
    {
        [Required(ErrorMessageResourceName = "CatalogTypeNameReq", ErrorMessageResourceType = typeof(rsrcCatalogs))]
        [Display(Name = "CatalogTypeName", ResourceType = typeof(rsrcModulTypes))]
        string CatalogTypeName { get; set; }

        [Required(ErrorMessageResourceName = "CreatedByReq", ErrorMessageResourceType = typeof(rsrcCatalogs))]
        [Display(Name = "CreatedBy", ResourceType = typeof(rsrcModulTypes))]
        int CreatedBy { get; set; }

        [Required(ErrorMessageResourceName = "ModifiedByReq", ErrorMessageResourceType = typeof(rsrcCatalogs))]
        [Display(Name = "ModifiedBy", ResourceType = typeof(rsrcModulTypes))]
        int ModifiedBy { get; set; }

    }
}
