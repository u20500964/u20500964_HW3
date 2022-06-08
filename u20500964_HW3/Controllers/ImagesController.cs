using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u20500964_HW3.Models;

namespace u20500964_HW3.Controllers
{
    public class ImagesController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            // 
            //Fetch all files in the Folder (Directory).
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Images/"));

            //Copy File names to Model collection.
            List<FileModel> files = new List<FileModel>();
            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }

            return View(files);

        }

        public FileResult Download(string FileName)
        {
            //Build the File Path.
            string path = Server.MapPath("~/Media/Images/") + FileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", FileName);
        }


        public ActionResult Delete(string FileName)
        {
            string fullPath = Request.MapPath("~/Media/Images/" + FileName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            return RedirectToAction("Index");
        }
    }
}