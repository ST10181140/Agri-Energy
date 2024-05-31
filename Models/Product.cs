﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgriEnergy.Models
{
  
        public class Product
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public string Category { get; set; }
            public DateTime ProductionDate { get; set; }
            public string ProductDescription { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public DateTime ExpirationDate { get; set; }
            public int FarmerID { get; set; }
        }
    }


