using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Riggen.Helper
{
    public class ImageUpload
    {
        private string directoryName;
        public ImageUpload(string directoryName)
        {
            this.directoryName = directoryName;
        }
        public string Upload(HttpPostedFileBase file)
        {

            if (file != null && file.ContentLength > 0)
            {
                var fileNames = Path.GetFileName(file.FileName);
                string fileId = Guid.NewGuid().ToString().Replace("-", "");
                var fileExt = Path.GetExtension(file.FileName);
                if (fileExt.ToLower().EndsWith(".png") || fileExt.ToLower().EndsWith(".jpg") || fileExt.ToLower().EndsWith(".gif"))
                {
                    var filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Images/" + directoryName), fileId + fileExt);
                    var directory = new DirectoryInfo(HostingEnvironment.MapPath("~/Content/Images/" + directoryName + "/"));
                    if (directory.Exists == false)
                    {
                        directory.Create();
                    }
                    file.SaveAs(filePath);
                    return "~/Content/Images/" + directoryName + "/" + fileId + fileExt;
                }
            }
            return "~/Content/Images/noimage.png";
        }
    }
}