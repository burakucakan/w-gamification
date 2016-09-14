using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.GM.CustomObjects
{
    public class UserObj : User
    {
        public string Msisdn { get { return base.UID; } }
    }
}
