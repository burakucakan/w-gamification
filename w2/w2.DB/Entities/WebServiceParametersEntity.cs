using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.DB
{
    [MetadataType(typeof(IWebServiceParameters))]
    public partial class WebServiceParameters : BaseEntity<WebServiceParameters>, IBaseEntity<WebServiceParameters>
    {
    }
}