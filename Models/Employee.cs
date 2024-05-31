using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgriEnergy.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeUsername { get; set; }
        public string EmployeePassword { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeEmail { get; set; }
        public string Department { get; set; }
        public DateTime JoinDate { get; set; }
    }
}