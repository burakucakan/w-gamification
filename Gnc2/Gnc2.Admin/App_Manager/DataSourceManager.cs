using Gnc2.DB.Virtual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace Gnc2.Admin.App_Manager
{
    public class DataSourceManager
    {
        public static List<SelectListItem> GetBannerTypes()
        {
            return App_Manager.SelectListHelper.SelectListEnum(typeof(Enums.BannerPosition));
        }

        public static List<SelectListItem> GetGender()
        {
            return App_Manager.SelectListHelper.SelectListEnum(typeof(Enums.Genders));
        }

        public static List<SelectListItem> GetDisableUser()
        {
            return App_Manager.SelectListHelper.SelectListEnum(typeof(Enums.DisableUsers));
        }

        public static List<SelectListItem> GetUserDateProcess()
        {
            return App_Manager.SelectListHelper.SelectListEnum(typeof(Enums.UserOrderType));
        }

        public static List<SelectListItem> GetCatelogProcess()
        {
            return App_Manager.SelectListHelper.SelectListEnum(typeof(Enums.CatalogOrderType));
        }


        
    }
}