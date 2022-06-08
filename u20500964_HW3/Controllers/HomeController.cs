using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace u20500964_HW3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string FileType, HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    if (FileType == "Image")
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Media/Images/"), _FileName);
                        file.SaveAs(_path);
                    }

                    if (FileType == "Video")
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Media/Videos/"), _FileName);
                        file.SaveAs(_path);
                    }
                    if (FileType == "Document")
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Media/Documents/"), _FileName);
                        file.SaveAs(_path);
                    }
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
            return View();
        }


    }
}