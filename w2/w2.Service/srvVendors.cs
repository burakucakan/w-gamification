using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w2.DB;

namespace w2.Service
{
    public class srvVendors : BaseService<Vendors>, IBaseService<Vendors>
    {
        public static Vendors GetByAuthKey(string AuthKey)
        {
            using (Context c = new Context())
            {
                Guid g;
                if (Guid.TryParse(AuthKey, out g))
                    return c.Vendors.Where(m => m.AuthKey == g).FirstOrDefault();
                else
                    return null;
            }
        }
    }
}
