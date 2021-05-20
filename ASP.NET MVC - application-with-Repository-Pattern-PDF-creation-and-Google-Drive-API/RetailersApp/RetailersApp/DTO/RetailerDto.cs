using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailersApp.DTO
{
    public class RetailerDto
    {
        public int Retailer_ID { get; set; }
        public string Retailer_Code { get; set; }
        public string Retailer_Name { get; set; }
        public string Retailer_Location { get; set; }
        public string image_url { get; set; }
    }
}