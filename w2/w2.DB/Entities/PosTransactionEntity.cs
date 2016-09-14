using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.DB
{
    [MetadataType(typeof(IPostTransaction))]
    public partial class PosTransaction : BaseEntity<PosTransaction>, IBaseEntity<PosTransaction>
    {
        
    }
}
