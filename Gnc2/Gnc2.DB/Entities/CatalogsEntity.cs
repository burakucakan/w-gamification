using Gnc2.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.DB
{
    [MetadataType(typeof(ICatalogs))]
    public partial class Catalogs : BaseEntity<Catalogs>, IBaseEntity<Catalogs>
    {
    }
}
