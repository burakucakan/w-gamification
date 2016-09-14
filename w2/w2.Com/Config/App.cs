using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.Com.Config
{
    public class App
    {
        public const string ApiKey = "3_4bOfh1SkOiFnuKtGq5zP1vuZJ4kzCWAjI9nofsqKDB2IhJaoj3_Ds34TO3UuOrL4";
        public const string key = "A4B38CCC-FDC4-4413-B6F2-085806B327E5";
        public const string SecretKey = "85dQctWxv4zF48qIb64RQmWITzl010Zkbv/x8efmSWA=";

        public const bool UseHttps = true;

        public static string Format = w2.Com.Params.Format.json.ToString();

        public static int LeaderboardTopCount = 5;

        public static string CallIdNoReq = "-1";

        public static int LowPointLimit = 50;
    }
}
