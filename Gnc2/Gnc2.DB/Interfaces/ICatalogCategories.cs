using Gnc2.Com.App_GlobalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.DB.Interfaces
{
    public interface ICatalogCategories : IBaseEntity<CatalogCategories>
    {
        [Required(ErrorMessageResourceName = "CategoryNameReq", ErrorMessageResourceType = typeof(rsrcCatalogCategories))]
        [Display(Name = "CategoryName", ResourceType = typeof(rsrcCatalogCategories))]
        string CategoryName { get; set; }
    }
}
