using Gnc2.Com.Helpers;
using Gnc2.Com.Virtual;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LIB.ExtentionMethods;
using Gnc2.Com.Helpers.UrlHelperExtensions;
using Gnc2.DB;

namespace Gnc2.Admin.Controllers
{
    public class UploadController : BaseController
    {
        private PathHelper.Images.Type ImageType;
        private PathHelper.TextFiles.Type TextType;
        private bool NotLiveImg;


        [HttpPost]
        public ActionResult PhotoUpload(HttpPostedFileBase FileUpload, PathHelper.Images.Type ImageType, bool ResizeDefault, int ResizeDefaultW, int ResizeDefaultH, bool NotLiveImg)
        {
            this.ImageType = ImageType;
            this.NotLiveImg = NotLiveImg;

            ViewBag.savedFileName = Com.General.ProjectUtil.GenerateImageName(Path.GetFileName(FileUpload.FileName));

            session.LastUploadedFile = ViewBag.savedFileName;

            FileUpload.SaveAs(FullPathPhysc(Enums.ImageSizeNaming.Original));

            ImageResizePreview();

            if (ResizeDefault)
                ImageResize(ResizeDefaultW, ResizeDefaultH, Enums.ImageSizeNaming.Default);

            var savedBig = (ResizeDefault) ? FullPath(Enums.ImageSizeNaming.Default) : FullPath(Enums.ImageSizeNaming.Original);

            return Json(new { savedFileName = ViewBag.savedFileName, savedBig = savedBig, pathPreview = FullPath(Enums.ImageSizeNaming.Preview) }, "text/plain");
        }


        [HttpPost]
        public ActionResult UploadTextFile(HttpPostedFileBase UploadTextFile, PathHelper.TextFiles.Type TextType)
        {
            this.TextType = TextType;

            ViewBag.savedFileName = Com.General.ProjectUtil.GenerateImageName(Path.GetFileName(UploadTextFile.FileName));

            session.LastUploadedFile = ViewBag.savedFileName;

            UploadTextFile.SaveAs(FullTextPath());

            session.PromoCodesTextFileName = ViewBag.savedFileName;
            session.PromoCodesTextFilePath = FullTextPath();
            session.PromoCodesFileStream = UploadTextFile;

            return Json(new { savedFileName = ViewBag.savedFileName }, "text/plain");
        }


        [HttpPost]
        public ActionResult PhotoRemove(string[] fileNames, PathHelper.Images.Type ImageType, bool NotLiveImg)
        {
            if (session.LastUploadedFile != "")
            {
                ViewBag.savedFileName = session.LastUploadedFile;

                this.ImageType = ImageType;
                this.NotLiveImg = NotLiveImg;

                DeleteImage(FullPathPhysc(Enums.ImageSizeNaming.Original));
                DeleteImage(FullPathPhysc(Enums.ImageSizeNaming.Default));
                DeleteImage(FullPathPhysc(Enums.ImageSizeNaming.Preview));

                ViewBag.savedFileName = session.LastUploadedFile = "";
            }
            return Json(new { }, "text/plain");
        }

        [HttpPost]
        public ActionResult FileRemove(string[] fileNames, PathHelper.TextFiles.Type TextType, bool NotLiveImg)
        {
           /* if (session.LastUploadedFile != "")
            {
                ViewBag.savedFileName = session.LastUploadedFile;

                this.ImageType = ImageType;
                this.NotLiveImg = NotLiveImg;

                DeleteImage(FullPathPhysc(Enums.ImageSizeNaming.Original));
                DeleteImage(FullPathPhysc(Enums.ImageSizeNaming.Default));
                DeleteImage(FullPathPhysc(Enums.ImageSizeNaming.Preview));

                ViewBag.savedFileName = session.LastUploadedFile = "";
            }*/
            return Json(new { }, "text/plain");
        }


        private static void DeleteImage(string FullPath)
        {
            if (System.IO.File.Exists(FullPath))
                try
                {
                    System.IO.File.Delete(FullPath);
                }
                catch (Exception) { }
        }


        private void ImageResize(int ResizeDefaultW, int ResizeDefaultH, Enums.ImageSizeNaming ImageSizeNaming)
        {
            LIB.ImageHelper imgHelper = new LIB.ImageHelper();

            if (ResizeDefaultH > 0)
                imgHelper.Crop(FullPathPhysc(Enums.ImageSizeNaming.Original), FullPathPhysc(ImageSizeNaming), ResizeDefaultW, ResizeDefaultH, true);
            else
                imgHelper.Resize(FullPathPhysc(Enums.ImageSizeNaming.Original), FullPathPhysc(ImageSizeNaming), ResizeDefaultW);
        }
        private void ImageResizePreview()
        {
            ImageResize((int)Enums.ImageSizes.Preview_W, 0, Enums.ImageSizeNaming.Preview);
        }

        private string FullPath(Enums.ImageSizeNaming ImageSizeNaming)
        {
            return ((string)PathHelper.Images.PathByType(this.ImageType, ViewBag.savedFileName, ImageSizeNaming)).ToFullPath();
        }

        private string FullPathPhysc(Enums.ImageSizeNaming ImageSizeNaming)
        {
            var path = ((string)PathHelper.Images.PathByType(this.ImageType, ViewBag.savedFileName, ImageSizeNaming)).ToPhysical();
            return (!this.NotLiveImg) ? path.ToFullPathPhysc() : path.ToFullPathAdminPhysc();
        }

        private string FullTextPath()
        {
            var path = ((string)PathHelper.TextFiles.PathByType(this.TextType, ViewBag.savedFileName)).ToPhysical();
            return (!this.NotLiveImg) ? path.ToFullPathPhysc() : path.ToFullPathAdminPhysc();
        }



      
    }
}
