using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgriEnergy.Models
{
    public class Farmer
    {
        public int FarmerID { get; set; }
        public string FarmerName { get; set; }
        public string FarmerSurname { get; set; }
        public string FarmerEmail { get; set; }
        public string FarmerPassword { get; set; }
        public string FarmerAddress { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JoinDate { get; set; }
    }
}