using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailersApp.Models;

namespace RetailersApp.Repository
{
    interface IRetailer
    {
        void InsertRetailer(Models.Retailer retailer);

        IEnumerable<Models.Retailer> GetRetailers();

        Models.Retailer GetRetailerByID(int retailerId);

        void UpdateRetailer(Models.Retailer retailer);

        void DeleteRetailer(int retailerId);

        //void Save();
    }
}
