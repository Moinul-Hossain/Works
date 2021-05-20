using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailersApp.DTO
{
    public class DepartmentDto
    {
        public int Department_ID { get; set; }
        public int Retailer_ID { get; set; }
        public string Department_Name { get; set; }
        public string Department_Code { get; set; }
        public string image_url { get; set; }
        public virtual RetailerDto Retailer { get; set; }
    }
}