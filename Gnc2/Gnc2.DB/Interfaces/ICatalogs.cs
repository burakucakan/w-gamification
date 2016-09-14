using Gnc2.Com.App_GlobalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.DB.Interfaces
{
    public interface ICatalogs : IBaseEntity<Catalogs>
    {

        [Required(ErrorMessageResourceName = "CatalogCategoriesIdReq", ErrorMessageResourceType = typeof(rsrcCatalogs))]
        [Display(Name = "CatalogCategoriesId", ResourceType = typeof(rsrcCatalogs))]
        int CatalogCategoriesId { get; set; }

        [Required(ErrorMessageResourceName = "CatalogTypeIdReq", ErrorMessageResourceType = typeof(rsrcCatalogs))]
        [Display(Name = "CatalogTypeId", ResourceType = typeof(rsrcCatalogs))]
        int CatalogTypeId { get; set; }

        //[Required(ErrorMessageResourceName = "ModulTypeNameReq", ErrorMessageResourceType = typeof(rsrcCatalogs))]
        //[Display(Name = "ModulTypeName", ResourceType = typeof(rsrcCatalogs))]
        //string ModulTypeName { get; set; }

        [Required(ErrorMessageResourceName = "CatalogNameReq", ErrorMessageResourceType = typeof(rsrcCatalogs))]
        [Display(Name = "CatalogName", ResourceType = typeof(rsrcCatalogs))]
        string CatalogName { get; set; }

        [Required(ErrorMessageResourceName = "CatalogPointReq", ErrorMessageResourceType = typeof(rsrcCatalogs))]
        [Display(Name = "CatalogPoint", ResourceType = typeof(rsrcCatalogs))]
        int CatalogPoint { get; set; }

        [Required(ErrorMessageResourceName = "CatalogFeaturesReq", ErrorMessageResourceType = typeof(rsrcCatalogs))]
        [Display(Name = "CatalogFeatures", ResourceType = typeof(rsrcCatalogs))]
        string CatalogFeatures { get; set; }

        [Required(ErrorMessageResourceName = "CatalogStartDateReq", ErrorMessageResourceType = typeof(rsrcCatalogs))]
        [Display(Name = "CatalogStartDate", ResourceType = typeof(rsrcCatalogs))]
        DateTime CatalogStartDate { get; set; }

        [Required(ErrorMessageResourceName = "CatalogEndDateReq", ErrorMessageResourceType = typeof(rsrcCatalogs))]
        [Display(Name = "CatalogEndDate", ResourceType = typeof(rsrcCatalogs))]
        DateTime CatalogEndDate { get; set; }

        [Required(ErrorMessageResourceName = "CatalogImageReq", ErrorMessageResourceType = typeof(rsrcCatalogs))]
        [Display(Name = "CatalogImage", ResourceType = typeof(rsrcCatalogs))]
        string CatalogImage { get; set; }

        [Required(ErrorMessageResourceName = "CatalogConditionReq", ErrorMessageResourceType = typeof(rsrcCatalogs))]
        [Display(Name = "CatalogCondition", ResourceType = typeof(rsrcCatalogs))]
        string CatalogCondition { get; set; }

    }
}
