using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIB.ExtentionMethods;
using Gnc2.Com.Virtual;

namespace Gnc2.Com.Helpers.UrlHelperExtensions
{
    public static class Extensions
    {
        
        public static string ToFullPath(this string val)
        {
            return LIB.Util.GetConfigValue(UrlHelper.Url.url_Static.ToString()).ToString().PathAppend(val);
        }
        public static string ToFullPathPhysc(this string val)
        {
            return LIB.Util.GetConfigValue(UrlHelper.Url.url_Static_phys.ToString()).ToString().PathAppend(val);
        }

        public static string ToFullPathAdmin(this string val)
        {
            return LIB.Util.GetConfigValue(UrlHelper.Url.url_Admin.ToString()).ToString().PathAppend(val);
        }
        public static string ToFullPathAdminPhysc(this string val)
        {
            return LIB.Util.GetConfigValue(UrlHelper.Url.url_Admin_phys.ToString()).ToString().PathAppend(val);
        }
    }
}

namespace Gnc2.Com.Helpers
{
    public class UrlHelper : LIB.UrlHelper
    {
        public enum Url
        {
            url_Web,
            url_Admin,
            url_Admin_phys,
            url_Static,
            url_Static_phys,
            url_UIAssets
        }

        public static string UrlWeb { get { return LIB.Util.GetConfigValue(Url.url_Web.ToString()); } }
        public static string UrlAdmin { get { return LIB.Util.GetConfigValue(Url.url_Admin.ToString()); } }
        public static string url_Admin_phys { get { return LIB.Util.GetConfigValue(Url.url_Admin_phys.ToString()); } }
        public static string UrlStatic { get { return LIB.Util.GetConfigValue(Url.url_Static.ToString()); } }
        public static string url_Static_phys { get { return LIB.Util.GetConfigValue(Url.url_Static_phys.ToString()); } }
        public static string UrlUIAssets { get { return LIB.Util.GetConfigValue(Url.url_UIAssets.ToString()); } }

        public class Images
        {

            public static string root = LIB.Util.GetConfigValue("path_imagesRoot");

            //folder names
            public enum Type
            {
                contents,
                adminusers,
                catalogs,
                banners,
                campaigns,
                users
            }

            public static string NameByType(Enums.ImageSizeNaming ImageSize, string FileName)
            {
                return ((int)ImageSize).ToString() + "_" + FileName;
            }

            public static string PathByType(Type Type, string FileName, Enums.ImageSizeNaming ImageSize)
            {
                return root.PathAppend(Type.ToString()).PathAppend(NameByType(ImageSize, FileName)).ToString();
            }

            public static string Content(string FileName, Enums.ImageSizeNaming ImageSize = Enums.ImageSizeNaming.Default)
            {
                return PathByType(Type.contents, FileName, ImageSize);
            }
            public static string AdminUser(string FileName, Enums.ImageSizeNaming ImageSize = Enums.ImageSizeNaming.Default)
            {
                return PathByType(Type.adminusers, FileName, ImageSize);
            }

            public static string Banner(string FileName, Enums.ImageSizeNaming ImageSize = Enums.ImageSizeNaming.Default)
            {
                return PathByType(Type.banners, FileName, ImageSize);
            }


            
            //public static string BannerPhysc(string FileName, Enums.ImageSizeNaming ImageSize = Enums.ImageSizeNaming.Default)
            //{
            //    return Banner(FileName, ImageSize).ToPhysical().ToFullPathPhysc();
            //}
        }
    

        public class TextFiles
        {

            public static string root = LIB.Util.GetConfigValue("path_textRoot");

            //folder names
            public enum Type
            {
                contents,
                adminusers,
                catalogs,
                promocodes,
                campaigns
            }

            public static string NameByType(string FileName)
            {
                return "_" + FileName;
            }

            public static string PathByType(Type Type, string FileName)
            {
                return root.PathAppend(Type.ToString()).PathAppend(NameByType(FileName)).ToString();
            }


            public static string Content(string FileName)
            {
                return PathByType(Type.promocodes, FileName);
            }
          
         
        }
    }
}