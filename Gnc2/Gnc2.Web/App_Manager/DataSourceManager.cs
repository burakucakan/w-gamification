using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace Gnc2.App_Manager
{
    public class DataSourceManager
    {
        public static List<SelectListItem> GetCities()
        {
            return App_Manager.SelectListHelper.SelectListEnum(typeof(Gnc2.DB.Virtual.Enums.Cities));
        }

        public static List<SelectListItem> GetGenders()
        {
            return App_Manager.SelectListHelper.SelectListEnum(typeof(Gnc2.DB.Virtual.Enums.Genders));
        }

        public static List<SelectListItem> GetCatalogOrderFilters()
        {
            return App_Manager.SelectListHelper.SelectListEnum(typeof(Gnc2.DB.Virtual.Enums.CatalogOrderFilters));
        }
    }
}