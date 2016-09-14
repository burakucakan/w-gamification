using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.DB
{
    [MetadataType(typeof(IUserCampaigns))]
    public partial class UserCampaigns : BaseEntity<UserCampaigns>, IBaseEntity<UserCampaigns>
    {
    }
}
