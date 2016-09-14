using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.DB
{
    [MetadataType(typeof(IWebServices))]
    public partial class WebServices : BaseEntity<WebServices>, IBaseEntity<WebServices>
    {
    }
}
