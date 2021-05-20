using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using RetailersApp.Models;

namespace RetailersApp.Repository
{
    public class Retailer : IRetailer
    {
        private RetailDBEntities DBContext;

        public Retailer(RetailDBEntities _DBContext)
        {
            this.DBContext = _DBContext;
        }

        public void InsertRetailer(Models.Retailer retailer)
        {
            DBContext.Retailers.Add(retailer);
            DBContext.SaveChanges();
        }

        public IEnumerable<Models.Retailer> GetRetailers()
        {
            return DBContext.Retailers.ToList();
        }

        public Models.Retailer GetRetailerByID(int retailerId)
        {
            return DBContext.Retailers.Find(retailerId);
        }

        public void UpdateRetailer(Models.Retailer retailer)
        {
            DBContext.Entry(retailer).State = System.Data.Entity.EntityState.Modified;
            DBContext.SaveChanges();
        }

        public void DeleteRetailer(int retailerId) {
            Models.Retailer retailer = DBContext.Retailers.Find(retailerId);
            DBContext.Retailers.Remove(retailer);
            DBContext.SaveChanges();
        }

    }
}