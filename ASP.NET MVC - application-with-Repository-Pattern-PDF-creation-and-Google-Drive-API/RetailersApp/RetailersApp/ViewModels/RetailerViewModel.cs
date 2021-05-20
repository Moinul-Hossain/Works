using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailersApp.ViewModels
{
    public class RetailerViewModel
    {
        public int RetailerID { get; set; }
        public string RetailerCode { get; set; }
        public string RetailerName { get; set; }
        public string RetailerLocation { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
    }
}