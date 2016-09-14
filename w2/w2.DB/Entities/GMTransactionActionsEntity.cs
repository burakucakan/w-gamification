using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.DB
{
    [MetadataType(typeof(IGMTransactionActions))]
    public partial class GMTransactionActions : BaseEntity<GMTransactionActions>, IBaseEntity<GMTransactionActions>
    {
        
    }
}
