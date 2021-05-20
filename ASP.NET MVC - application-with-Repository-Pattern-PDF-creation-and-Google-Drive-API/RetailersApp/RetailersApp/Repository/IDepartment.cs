using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using RetailersApp.Models;
using RetailersApp.DTO;

namespace RetailersApp.Repository
{
    interface IDepartment
    {
        void InsertDepartment (Models.Department department);

        IEnumerable<Models.Department> GetDepartments();

        //Models.Department GetDepartmentByID(int departmentId);
        DepartmentDto GetDepartmentByID(int departmentId);

        //void UpdateDepartment (Models.Department department);
        void UpdateDepartment(int departmentId, DepartmentDto department);

        void DeleteDepartment (int departmentId);
    }
}
