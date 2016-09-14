using Gnc2.Com.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Gnc2.Com.Virtual;
using Gnc2.Com.Helpers.UrlHelperExtensions;

namespace Gnc2.Admin.Models
{

    public class UploadModel
    {
        public string UploadElementName { get; set; }

        [DataType(DataType.Upload)]
        public string FileName { get; set; }

        public PathHelper.Images.Type ImageType { get; set; }

        public PathHelper.TextFiles.Type TextType { get; set; }

        [EnumDataType(typeof(Gnc2.Admin.App_Manager.ConfigManager.ConfigName))]
        public string PhysicalImagePath { get; set; }

        public bool ResizeDefault { get; set; }
        public Enums.ImageSizes ResizeDefaultW { get; set; }
        public Enums.ImageSizes ResizeDefaultH { get; set; }

        public bool NotLiveImg { get; set; }
        public bool NotRequired { get; set; }

        public string srcBig
        {
            get
            {
                if (!String.IsNullOrEmpty(FileName))
                {
                    var path = PathHelper.Images.PathByType(ImageType, FileName, Enums.ImageSizeNaming.Original);
                    return (NotLiveImg) ? path : path.ToFullPath();
                }
                return "";
            }
        }

        public string srcPreview
        {
            get
            {
                if (!String.IsNullOrEmpty(FileName))
                {
                    var path = PathHelper.Images.PathByType(ImageType, FileName, Enums.ImageSizeNaming.Preview);
                    return (NotLiveImg) ? path : path.ToFullPath();
                }
                return "";
            }
        }
    }
}