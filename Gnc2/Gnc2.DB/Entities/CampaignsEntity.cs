using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.DB
{
    [MetadataType(typeof(ICampaigns))]
    public partial class Campaigns : BaseEntity<Campaigns>, IBaseEntity<Campaigns>
    {

    } 
}
