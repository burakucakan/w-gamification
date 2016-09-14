using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.DB
{
    public class BaseEntity<T> where T : class , IBaseEntity<T>
    {        

    }

}
