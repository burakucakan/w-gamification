using Gnc2.Com.App_GlobalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.DB.Interfaces
{
    public interface ICatalogType : IBaseEntity<CatalogType>
    {
        [Required(ErrorMessageResourceName = "CatalogTypeNameReq", ErrorMessageResourceType = typeof(rsrcCatalogType))]
        [Display(Name = "CatalogTypeName", ResourceType = typeof(rsrcCatalogType))]
        string CatalogTypeName { get; set; }
    }
}
