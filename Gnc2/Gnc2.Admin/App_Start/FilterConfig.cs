using System.Web;
using System.Web.Mvc;
using Gnc2.Admin.Filters;

namespace Gnc2.Admin
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new InternationalizationAttribute());
        }
    }
}