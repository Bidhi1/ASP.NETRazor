using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADO_Example.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        [DisplayName("Patient Name")]
        public string PatientName { get; set;}

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int PatientAge { get; set; }

        public string Remarks { get; set; }

        public bool isActive { get; set; }

    }
}