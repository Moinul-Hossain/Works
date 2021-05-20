using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using RetailersApp.Models;
using RetailersApp.DTO;
using AutoMapper;

namespace RetailersApp.Repository
{
    public class Department : IDepartment
    {
        private RetailDBEntities DBContext; private MapperConfiguration config;  private IMapper iMapper;     

        public Department (RetailDBEntities _DBContext)
        {
            this.DBContext = _DBContext;
            config = new MapperConfiguration(cfg=> {
                cfg.CreateMap<Models.Retailer, RetailerDto>();
                // AutoMapper congig with nested type
                cfg.CreateMap<Models.Department, DepartmentDto>()
                .ForMember(dest => dest.Retailer, act => act.MapFrom(src => src.Retailer));
                });
            iMapper = config.CreateMapper();
        }

        public void InsertDepartment (Models.Department department)
        {
            DBContext.Departments.Add(department);
            DBContext.SaveChanges();
        }

        public IEnumerable<Models.Department> GetDepartments()
        {
            return DBContext.Departments.ToList();
        }

        // Method declaration before AutoMapper
        // public Models.Department GetDepartmentByID(int departmentId)
        public DepartmentDto GetDepartmentByID(int departmentId)
        {
            // Code before AutoMapper
            //return DBContext.Departments.Find(departmentId);

            // Code after AutoMapper
            Models.Department deptSource = DBContext.Departments.Find(departmentId);
            DepartmentDto deptDestination = iMapper.Map<Models.Department, DepartmentDto>(deptSource);            
            return deptDestination;
        }

        //public void UpdateDepartment (Models.Department department)
        // After AutoMapper
        public void UpdateDepartment(int id, DepartmentDto department)
        {
            //var _department = DBContext.Departments.Single(x => x.Department_ID == id);            
            Models.Department _department = iMapper.Map<DepartmentDto, Models.Department>(department);
            DBContext.Entry(_department).State = System.Data.Entity.EntityState.Modified;
            DBContext.SaveChanges();
        }

        public void DeleteDepartment (int departmentId)
        {
            Models.Department department = DBContext.Departments.Find(departmentId);
            DBContext.Departments.Remove(department);
            DBContext.SaveChanges();
        }
    }
}