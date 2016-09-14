using Gnc2.Com.General;
using Gnc2.Com.Helpers;
using Kendo.Mvc.UI.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gnc2.Com.Helpers.UrlHelperExtensions;

namespace Gnc2.Admin.App_Manager
{
    public class KendoManager
    {
        public static string DateFormat = "{0:" + GlobalVars.dateFormat + "}";
        public static string GridName = "Grid";
        public static string ClientTemplateCheck(string Field)
        {
            return "#= " + Field + " ? \"<span class='k-icon k-i-tick'></span>\" : '' #";
        }

        public static string ClientTemplateDate(string DateTimeValue)
        {
            return "#= " + DateTimeValue + " ? kendo.toString(" + DateTimeValue + ",\"" + GlobalVars.dateFormat + "\") : '' #";
        }

        public static string ClientTemplateUserImage(string Image)
        {

            int typePreview = (int)Gnc2.Com.Virtual.Enums.ImageSizeNaming.Preview;

            int typeOrginal = (int)Gnc2.Com.Virtual.Enums.ImageSizeNaming.Original;


            string root = Gnc2.Com.Helpers.PathHelper.UrlStatic +  Gnc2.Com.Helpers.PathHelper.Images.root;

            string path = Gnc2.Com.Helpers.PathHelper.Images.Type.users.ToString();

            return "<a href=\"" + root + path + "/" + typeOrginal + "_" + "#=" + Image + " #\" class=\"cb\"><img src=\"" + root + path + "/" + typePreview + "_" + "#=" + Image + " #\" /></a>";

          //  return "<img src=\"" + root + path +"/#=" + Image + " #\" />";
            
        }

        public static string ClientTemplateCatalogImage(string Image)
        {


            int typePreview = (int)Gnc2.Com.Virtual.Enums.ImageSizeNaming.Preview;

            int typeOrginal = (int)Gnc2.Com.Virtual.Enums.ImageSizeNaming.Original;

            string root = Gnc2.Com.Helpers.PathHelper.UrlStatic + Gnc2.Com.Helpers.PathHelper.Images.root;

            string path = Gnc2.Com.Helpers.PathHelper.Images.Type.contents.ToString();

            return "<a href=\"" + root + path + "/" + typeOrginal + "_" + "#=" + Image + " #\" class=\"cb\"><img src=\"" + root + path + "/" + typePreview + "_" + "#=" + Image + " #\" /></a>";


        }


        public static string ClientTemplateCampaignsImage(string Image)
        {

            string root = Gnc2.Com.Helpers.PathHelper.UrlStatic + Gnc2.Com.Helpers.PathHelper.Images.root;

            int typePreview = (int)Gnc2.Com.Virtual.Enums.ImageSizeNaming.Preview;
            
            int typeOrginal = (int)Gnc2.Com.Virtual.Enums.ImageSizeNaming.Original;

            string path = Gnc2.Com.Helpers.PathHelper.Images.Type.campaigns.ToString();

            return "<a href=\"" + root + path + "/" + typeOrginal + "_" + "#=" + Image + " #\" class=\"cb\"><img src=\"" + root + path + "/" + typePreview + "_" + "#=" + Image + " #\" /></a>";

        }

        public static string ClientTemplateBannerImage(string Image)
        {

            string root = Gnc2.Com.Helpers.PathHelper.UrlStatic + Gnc2.Com.Helpers.PathHelper.Images.root;


            int typePreview = (int)Gnc2.Com.Virtual.Enums.ImageSizeNaming.Preview;
            int typeOrginal = (int)Gnc2.Com.Virtual.Enums.ImageSizeNaming.Original;

            string path = Gnc2.Com.Helpers.PathHelper.Images.Type.banners.ToString() + "/";

            return "<a href=\"" + root + path + typeOrginal + "_" + "#=" + Image + " #\" class=\"cb\"><img src=\"" + root + path + typePreview + "_" + "#=" + Image + " #\" /></a>";

        }

        public static string ClientTemplateAdminImage(string FileName)
        {
            var DefaultPath = PathHelper.Images.AdminUser(FileName, Com.Virtual.Enums.ImageSizeNaming.Original).ToFullPathAdmin();
            var PreviewPath = PathHelper.Images.AdminUser(FileName, Com.Virtual.Enums.ImageSizeNaming.Preview).ToFullPathAdmin();

            DefaultPath = DefaultPath.Replace(FileName, "#= FileName #");
            PreviewPath = PreviewPath.Replace(FileName, "#= FileName #");

            return "<a class='cb' href='" + DefaultPath + "'><img src='" + PreviewPath + "' onerror=\"NoImage(this)\" /></a>";
        }
       
       
        public static string ClientTemplateGender(string Gender)
        {
            return "#= " + Gender + " == 1 ? \"Erkek\" : 'Kadın' #";
        }

        //public static string ClientTemplateAdminImage(string FileName)
        //{
        //    var DefaultPath = PathHelper.Images.AdminUser(FileName, Com.Enums.Parameter.ImageSizeNaming.Default).ToFullPathAdmin();
        //    var PreviewPath = PathHelper.Images.AdminUser(FileName, Com.Enums.Parameter.ImageSizeNaming.Preview).ToFullPathAdmin();

        //    DefaultPath = DefaultPath.Replace(FileName, "#= FileName #");
        //    PreviewPath = PreviewPath.Replace(FileName, "#= FileName #");

        //    return "<a class='cb' href='" + DefaultPath + "'><img src='" + PreviewPath + "' /></a>";
        //}

        public static string HtmlEditIcon = "<span class=\"k-icon k-i-pencil\"></span>";

        public static Action<PageableBuilder> pagerSettings = new Action<PageableBuilder>(
            p => p
            .Input(true)
            .PageSizes(new int[] { 5, 10, 20, 50, 100, 250, 500 })
            .Messages(pagerMessages)
        );

        public static Action<PageableMessagesBuilder> pagerMessages = new Action<PageableMessagesBuilder>(
            m => m
                .Empty(Resources.Kendo.PagerEmpty)
                .First(Resources.Kendo.PagerFirst)
                .ItemsPerPage(Resources.Kendo.PagerItemsPerPage)
                .Last(Resources.Kendo.PagerLast)
                .Next(Resources.Kendo.PagerNext)
                .Of(Resources.Kendo.PagerOf)
                .Page(Resources.Kendo.PagerPage)
                .Previous(Resources.Kendo.PagerPrevious)
                .Previous(Resources.Kendo.PagerRefresh)
                .Display(Resources.Kendo.PagerDisplay)
        );

        public static Action<GridFilterableSettingsBuilder> filterSettings = new Action<GridFilterableSettingsBuilder>
            (c => c
                    .Messages(
                        msg => msg
                            .Info(Resources.Kendo.FilterMsgInfo)
                            .Or(Resources.Kendo.FilterMsgOr)
                            .And(Resources.Kendo.FilterMsgAnd)
                            .IsTrue(Resources.Kendo.FilterMsgIsTrue)
                            .IsFalse(Resources.Kendo.FilterMsgIsFalse)
                            .Filter(Resources.Kendo.FilterMsgFilter)
                            .Clear(Resources.Kendo.FilterMsgClear)
                    )
                    .Operators(
                        opList => opList
                            .ForString(t => t
                                .IsEqualTo(Resources.Kendo.FilterOpStrIsEqualTo)
                                .IsNotEqualTo(Resources.Kendo.FilterOpStrIsNotEqualTo)
                                .StartsWith(Resources.Kendo.FilterOpStrStartsWith)
                                .EndsWith(Resources.Kendo.FilterOpStrEndsWith)
                                .Contains(Resources.Kendo.FilterOpStrContains)
                                .DoesNotContain(Resources.Kendo.FilterOpStrDoesNotContain))

                            .ForNumber(t => t
                                .IsEqualTo(Resources.Kendo.FilterOpNumIsEqualTo)
                                .IsGreaterThan(Resources.Kendo.FilterOpNumIsGreaterThan)
                                .IsGreaterThanOrEqualTo(Resources.Kendo.FilterOpNumIsGreaterThanOrEqualTo)
                                .IsLessThan(Resources.Kendo.FilterOpNumIsLessThan)
                                .IsLessThanOrEqualTo(Resources.Kendo.FilterOpNumIsLessThanOrEqualTo)
                                .IsNotEqualTo(Resources.Kendo.FilterOpNumIsNotEqualTo))

                            .ForDate(t => t
                                .IsEqualTo(Resources.Kendo.FilterOpDateIsEqualTo)
                                .IsGreaterThan(Resources.Kendo.FilterOpDateIsGreaterThan)
                                .IsGreaterThanOrEqualTo(Resources.Kendo.FilterOpDateIsGreaterThanOrEqualTo)
                                .IsLessThan(Resources.Kendo.FilterOpDateIsLessThan)
                                .IsLessThanOrEqualTo(Resources.Kendo.FilterOpDateIsLessThanOrEqualTo)
                                .IsNotEqualTo(Resources.Kendo.FilterOpDateIsNotEqualTo))
                    )
            );
    }
}