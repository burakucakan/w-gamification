using Gnc2.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Gnc2.Admin.Controllers
{
    [AuthorizeAttribute]
    public class BaseAuthorizedController : BaseController
    {
    }

}
