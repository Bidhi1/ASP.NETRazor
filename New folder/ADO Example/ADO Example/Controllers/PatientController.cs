using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADO_Example.DAL;
using ADO_Example.Models;

namespace ADO_Example.Controllers
{
    public class PatientController : Controller
    {
        Patient_DAL _patientDAL= new Patient_DAL();
        // GET: Patient
        public ActionResult Index()
        {
            var patientList =_patientDAL.GetAllPatients();
            if(patientList.Count == 0)
            {
                TempData["InfoMessage"] = "Currently patients not available in the Database...";
            }
            return View(patientList);
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var patient = _patientDAL.GetPatientById(id).FirstOrDefault();

                if (patient == null)
                {
                    TempData["InfoMessage"] = "Patient not available with ID" + id.ToString();
                    return RedirectToAction("Index");
                }
                return View(patient);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        public ActionResult Create(Patient patient)
        {
                bool IsInserted = false;

            try
            {

                if (ModelState.IsValid)
                {
                    IsInserted = _patientDAL.InsertPatient(patient);
                    if (IsInserted)
                    {
                        TempData["SuccessMessage"] = "Patient details saved successfully...";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Patient is already available/Unable to save the patient details.";
                    }
                }
                    return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
            
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int id)
        {
            var patients = _patientDAL.GetPatientById(id).FirstOrDefault();

            if (patients == null)
            {
                TempData["InfoMessage"] = "Patient not available with ID" + id.ToString();
                return RedirectToAction("Index");
            }
            return View(patients);
        }

        // POST: Patient/Edit/5
        [HttpPost,ActionName("Edit")]
        public ActionResult UpdatePatient(Patient patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool IsUpdated = _patientDAL.UpdatePatient(patient);

                    if (IsUpdated)
                    {
                        TempData["SuccessMessage"] = "Patient details updated successfully...";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Patient is already available/Unable to update the patient details.";
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var patient = _patientDAL.GetPatientById(id).FirstOrDefault();

                if (patient == null)
                {
                    TempData["InfoMessage"] = "Product not available with id" + id.ToString();
                    return RedirectToAction("Index");
                }
                return View(patient);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: Patient/Delete/5
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                string result = _patientDAL.DeletePatient(id);

                if (result.Contains("deleted"))
                {
                    TempData["SuccessMessage"] = result;
                }
                else
                {
                    TempData["ErrorMessage"] = result;

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
