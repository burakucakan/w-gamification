using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gigya.DB
{
    public interface IBaseEntity
    {
        System.Guid Id { get; set; }
        System.DateTime CreateDate { get; set; }
    }
}
