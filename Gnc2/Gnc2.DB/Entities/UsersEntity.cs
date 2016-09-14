using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.DB
{
    [MetadataType(typeof(IUsers))]
    public partial class Users : BaseEntity<Users>, IBaseEntity<Users>
    {      
    }
}
