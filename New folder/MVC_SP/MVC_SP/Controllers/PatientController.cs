using MVC_SP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MVC_SP.DAL;

namespace MVC_SP.Controllers
{
    public class PatientController:Controller

    {
        PatientDAL db = new PatientDAL();

        public ActionResult Index()
        {
            string id = "1";
             return View(db.GetData(id).ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Patients obj) 
        {



            if (db.Insert(obj))
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {

            var patient = db.GetData(id);
            if (patient == null)
            {
                
            }
            return View(patient);
        }

        [HttpPost]
        public ActionResult Edit(Patients obj)
        {
            if (db.Update(obj))
            {
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public ActionResult Delete(int id)
        {
            var patient = db.GetData(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (db.Delete(id))
            {
                return RedirectToAction("Index");
            }
            return View();
        }





    }
}