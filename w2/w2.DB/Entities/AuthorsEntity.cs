using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.DB
{
    [MetadataType(typeof(IVendors))]
    public partial class Vendors : BaseEntity<Vendors>, IBaseEntity<Vendors>
    {

    }
}
