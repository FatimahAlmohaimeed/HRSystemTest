using HRSystemTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRSystemTest.Models
{
    public class CreateEmployeeModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}