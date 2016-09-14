using Gnc2.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gnc2.DB;

namespace Gnc2.DB
{
    [MetadataType(typeof(IPromocCodeTypes))]
    public partial class PromoCodeTypes : BaseEntity<PromoCodeTypes>, IBaseEntity<PromoCodeTypes>
    {

    }
}
