using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya.Socialize.CustomModels
{
    public class NotifyUserLogin
    {

        public string Msisdn { get; set; }
        public string Key { get; set; }
        /// <summary>
        /// Name of the club, event, campaign etc.
        /// </summary>
        public string Cid { get; set; }
    }
}
