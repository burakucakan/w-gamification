using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.Com.General
{
    public class GlobalVars
    {
        public static string Culture;

        public static string OrderMax = "99999999";
        public static int OrderLength = 4;
        public static int OrderLengthMin = 2;

        public static int CurrAdminId;

        public static string dateFormat = "dd/MM/yyyy";

        public static string[] arrExtensionsImg = { ".jpg", ".jpeg", ".gif", ".png" };
        public static string ExtensionsImg = ".jpg, .jpeg, .gif, .png";

        public const string ImgValidationExpression = "(.*\\.([gG][iI][fF]|[jJ][pP][gG]|[jJ][pP][eE][gG])$)";

        public const string UrlRewriteExtension = "";

        public const string ImgNaming = "TurkcellGnc2_";
        public const string NoPictureFileName = "NoPicture.jpg";
        public const string NoPicturePath = "images/app_utils/noimage.jpg";

        public const int EnumValueAll = 0;
        public const string DdlInitialValue = "-1";

        public const int NameCharLimit = 11;
        public const string NameExtChars = "..";

        public const int MaskedMsisdnLength = 4;
    }
}
