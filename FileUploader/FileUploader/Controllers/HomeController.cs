using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using FileUploader.Models;
using System.Drawing.Drawing2D;



namespace FileUploader.Controllers
{
    public class HomeController : Controller
    {
        public object file { get; private set; }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Employee emp)
        {
       
            string path =Server.MapPath ("~/App_Data/File");
            string fileName = Path.GetFileName(emp.File.FileName);

            string fullPath = Path.Combine(path, fileName);

            emp.File.SaveAs(fullPath);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public FileResult GetFile(string fileName)
        {
            var dir = Server.MapPath("/App_Data/File");
            var path = Path.Combine(dir,fileName); 
            return base.File(path, "image/jpeg" , "application/pdf");
            
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



            [HttpPost]
            public ActionResult Upload(Employee model)
            {
                if (model.File != null && model.File.ContentLength > 0)
                {
                    if (model.File.ContentLength > 10485760) // 10 MB
                    {
                        //Compress File.
                    }

                    var fileName = Path.GetFileName(model.File.FileName);
                    var path = Path.Combine(Server.MapPath("~/App_data/File"), fileName);
                    model.File.SaveAs(path);
                }

                return RedirectToAction("Display");
            }

        public virtual ActionResult Display(int fileId, bool isFile)
        {
            //var viewmodel = file.(fileId, isFile);
            return View();
        }


    }
}