using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Patients.Controllers
{
    public class HomeController : Controller
    {
        PatientsDBContext _context = new PatientsDBContext();
        public ActionResult Index()
        {
            var listofData = _context.Patients.ToList();
            return View(listofData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public  ActionResult Create(Patient model)
        {
            _context.Patients.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Inserted Successfully";
            return View();
        }

        [HttpGet]

        public ActionResult Edit(int id)
        {
            var data = _context.Patients.Where(x => x.PatientId == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]

        public ActionResult Edit(Patient model)
        {
            var data = _context.Patients.Where(x => x.PatientId == model.PatientId).FirstOrDefault();
            if(data != null)
            {
                data.PatientAddress = model.PatientAddress;
                data.PatientPhone = model.PatientPhone;
                data.PatientName = model.PatientName;
                _context.SaveChanges();
               
            }
            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {
            var data = _context.Patients.Where(x => x.PatientId == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = _context.Patients.Where(x => x.PatientId == id).FirstOrDefault();
            _context.Patients.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Record Deleted Successfully";
            return RedirectToAction("index");
        }
       
    }
}