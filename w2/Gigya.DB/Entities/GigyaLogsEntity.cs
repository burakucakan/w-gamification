using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gigya.DB
{
    [MetadataType(typeof(IGigyaLogs))]
    public partial class GigyaLogs : BaseEntity, IBaseEntity
    {
    }
}