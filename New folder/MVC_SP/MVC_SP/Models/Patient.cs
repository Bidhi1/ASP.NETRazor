using Antlr.Runtime.Tree;
using MVC_SP.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_SP.Models
{
    public class Patients
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public int Age { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }

        //public void Save(Patients oPatient)
        //{
        //    PatientDAL patientDAL= new PatientDAL();
        //    oPatientDAL.Save(oPatient);
        //}
    }
}