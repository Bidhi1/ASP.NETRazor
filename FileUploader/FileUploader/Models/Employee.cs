﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUploader.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public HttpPostedFileBase File { get; set; }

    }
}