using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RetailersApp.Repository;
using RetailersApp.DTO;
using AutoMapper;

namespace RetailersApp.Controllers
{
    public class DepartmentsController : Controller
    {
        private IDepartment department;
        private IRetailer retailer;
        private MapperConfiguration config;
        private IMapper iMapper;

        public DepartmentsController()
        {
            this.department = new Department(new Models.RetailDBEntities());
            this.retailer = new Retailer(new Models.RetailDBEntities());

            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Models.Retailer, RetailerDto>();
                // AutoMapper congig with nested type
                cfg.CreateMap<Models.Department, DepartmentDto>()
                .ForMember(dest => dest.Retailer, act => act.MapFrom(src => src.Retailer));
            });
            iMapper = config.CreateMapper();
        }

        // GET: Departments
        public ActionResult Index()
        {
            var list = department.GetDepartments().ToList();
            return View(list);
        }

        // GET: Departments/Details/5
        public ActionResult Details(int id)
        {
            var _department = department.GetDepartmentByID(id);
            return View(_department);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var retailers = this.retailer.GetRetailers().ToList();
            ViewBag.Retailer_ID = new SelectList(retailers, "Retailer_ID", "Retailer_Name");
            return View();
        }


        [HttpPost]
        public ActionResult Create(FormCollection collection, Models.Department department)
        {
            try
            {
                Models.Department _department = new Models.Department();
                _department.Retailer_ID = department.Retailer_ID;
                _department.Department_Name = department.Department_Name;
                _department.Department_Code = department.Department_Code;
                _department.Retailer = department.Retailer;

                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase file = Request.Files["ImageFile"];
                    try
                    {
                        if (file.ContentLength > 0)
                        {
                            string _fileName = Path.GetFileName(file.FileName);
                            string _path = Path.Combine(Server.MapPath("~/Images"), _fileName);
                            _department.image_url = _fileName;
                            file.SaveAs(_path);
                        }
                    }
                    catch
                    {
                        ViewBag.Message = "File upload failed!!";
                        return View();
                    }
                }

                this.department.InsertDepartment(_department);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            /*
            var _department = this.department.GetDepartmentByID(id); // getting records by id GetEmployeeByID(ID)

            var retailers = this.retailer.GetRetailers().ToList();
            ViewBag.Retailer_ID = new SelectList(retailers, "Retailer_ID", "Retailer_Name", _department.Retailer_ID);

            var DepartmentEdit = new Models.Department();
            DepartmentEdit.Department_ID = id;
            DepartmentEdit.Retailer_ID = _department.Retailer_ID;
            DepartmentEdit.Department_Name = _department.Department_Name;
            DepartmentEdit.Department_Code = _department.Department_Code;            
            DepartmentEdit.image_url = _department.image_url;
            return View(DepartmentEdit);
            */

            // Using the Department DTO from the Department Repository
            DTO.DepartmentDto department = this.department.GetDepartmentByID(id);

            // Retailers dropdown
            var retailers = this.retailer.GetRetailers().ToList();
            ViewBag.Retailer_ID = new SelectList(retailers, "Retailer_ID", "Retailer_Name", department.Retailer_ID);

            return View(department);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection, Models.Department department)
        {
            try
            {
                /*
                // Before AutoMapper
                Models.Department _department = new Models.Department();
                _department.Department_ID = department.Department_ID;
                _department.Retailer_ID = department.Retailer_ID;
                _department.Department_Name = department.Department_Name;
                _department.Department_Code = department.Department_Code.Trim();                
                _department.image_url = department.image_url;   // if not new file uploaded
                */

                DepartmentDto _department = iMapper.Map<Models.Department, DepartmentDto>(department);
                

                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase file = Request.Files["ImageFile"];
                    try
                    {
                        if (file.ContentLength > 0)
                        {
                            // delete old image
                            string oldFilePath = Server.MapPath("~/Images/" + department.image_url);
                            if (System.IO.File.Exists(oldFilePath))
                            {
                                System.IO.File.Delete(oldFilePath);
                            }

                            string _fileName = Path.GetFileName(file.FileName);
                            string _path = Path.Combine(Server.MapPath("~/Images"), _fileName);
                            _department.image_url = _fileName;
                            file.SaveAs(_path);
                        }
                    }
                    catch
                    {
                        ViewBag.Message = "File upload failed!!";
                        return View();
                    }
                }
                this.department.UpdateDepartment(_department.Department_ID, _department);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int id)
        {
            // Before AutoMapper
            //Models.Department department = this.department.GetDepartmentByID(id);

            DTO.DepartmentDto department = this.department.GetDepartmentByID(id); 
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // delete image
                var _department = this.department.GetDepartmentByID(id);
                string filePath = Server.MapPath("~/Images/" + _department.image_url);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                this.department.DeleteDepartment(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
