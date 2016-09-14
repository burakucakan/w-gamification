using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.Com
{
    public class Util
    {
        public static string GetHttpProtocolStr() {
            return w2.Com.Config.App.UseHttps ? "http://" : "https://";
        }
    }
}
