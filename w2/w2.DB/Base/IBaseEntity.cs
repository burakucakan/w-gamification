using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.DB
{
    public interface IBaseEntity<T> where T : class
    {
         int Id { get; set; }
         System.DateTime CreateDate { get; set; }
         System.DateTime? ModifyDate { get; set; }
         bool IsActive { get; set; }
         bool IsDeleted { get; set; }
    }
}
