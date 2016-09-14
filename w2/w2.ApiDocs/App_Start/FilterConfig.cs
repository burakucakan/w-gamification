using System.Web;
using System.Web.Mvc;

namespace Gnc2.ServiceDoc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}