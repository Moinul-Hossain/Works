using System;
using System.Collections.Generic;

using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;

using System.Linq;
using System.Web;
using System.Web.Mvc;
using RetailersApp.Repository;
using RetailersApp.GoogleDriveAPI;

namespace RetailersApp.Controllers
{
    public class RetailersController : Controller
    {
        private IRetailer retailer;
        private IDepartment department;

        public RetailersController()
        {
            this.retailer = new Retailer(new Models.RetailDBEntities());
            this.department = new Department(new Models.RetailDBEntities());
        }

        // GET: Retailers
        public ActionResult Index()
        {
            var list = retailer.GetRetailers().ToList();
            return View(list);
        }

        // GET: Retailers/Details/5
        public ActionResult Details(int id)
        {
            var _retailer = retailer.GetRetailerByID(id);
            return View(_retailer);
        }

        [HttpGet]
        public ActionResult Create()

        {
            return View(new Models.Retailer());

        }

        [HttpPost]
        public ActionResult Create(FormCollection collection, Models.Retailer retailer)
        {
            try
            {
                Models.Retailer _retailer = new Models.Retailer();
                _retailer.Retailer_Name = retailer.Retailer_Name;
                _retailer.Retailer_Code = retailer.Retailer_Code;
                _retailer.Retailer_Location = retailer.Retailer_Location;

                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase file = Request.Files["ImageFile"];
                    try
                    {
                        if (file.ContentLength > 0)
                        {
                            string _fileName = Path.GetFileName(file.FileName);
                            string _path = Path.Combine(Server.MapPath("~/Images"), _fileName);
                            _retailer.image_url = _fileName;
                            file.SaveAs(_path);
                        }
                    }
                    catch
                    {
                        ViewBag.Message = "File upload failed!!";
                        return View();
                    }
                }
                
                this.retailer.InsertRetailer(_retailer);                

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
            var _retailer = this.retailer.GetRetailerByID(id); // getting records by id GetEmployeeByID(ID)

            var retailerEdit = new Models.Retailer();
            retailerEdit.Retailer_ID = id;
            retailerEdit.Retailer_Name = _retailer.Retailer_Name;
            retailerEdit.Retailer_Code = _retailer.Retailer_Code;
            retailerEdit.Retailer_Location = _retailer.Retailer_Location;
            retailerEdit.image_url = _retailer.image_url;
            return View(retailerEdit);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection, Models.Retailer retailer)
        {
            try
            {

             Models.Retailer _retailer = new Models.Retailer();
            _retailer.Retailer_ID = retailer.Retailer_ID;
            _retailer.Retailer_Name = retailer.Retailer_Name;
            _retailer.Retailer_Code = retailer.Retailer_Code.Trim();
            _retailer.Retailer_Location = retailer.Retailer_Location;
            _retailer.image_url = retailer.image_url;   // if not new file uploaded

                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase file = Request.Files["ImageFile"];
                    try
                    {
                        if (file.ContentLength > 0)
                        {
                        // delete old image
                        string oldFilePath = Server.MapPath("~/Images/" + retailer.image_url);
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }

                        string _fileName = Path.GetFileName(file.FileName);
                            string _path = Path.Combine(Server.MapPath("~/Images"), _fileName);
                            _retailer.image_url = _fileName;
                            file.SaveAs(_path);
                        }
                    }
                    catch
                    {
                        ViewBag.Message = "File upload failed!!";
                        return View();
                    }
                }

                this.retailer.UpdateRetailer(_retailer);

                return RedirectToAction("Index");

            }

            catch

            {

                return View();

            }

        }

        // GET: Retailers/Delete/5
        public ActionResult Delete(int id)
        {
            Models.Retailer retailer = this.retailer.GetRetailerByID(id);
            return View(retailer);
        }

        // POST: Retailers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // delete image
                var _retailer = retailer.GetRetailerByID(id);
                string filePath = Server.MapPath("~/Images/" + _retailer.image_url);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                this.retailer.DeleteRetailer(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // Combined Report (LINQ)
        public ActionResult Report()
        {
            //var _retailers = this.retailer.GetRetailers().ToList();
            List<Models.Retailer> retailers = this.retailer.GetRetailers().ToList();

            //var _departments = this.department.GetDepartments().ToList();
            List<Models.Department> departments = this.department.GetDepartments().ToList();

            
            var query = (from r in retailers
                        join d in departments on r.Retailer_ID equals d.Retailer_ID 
                        select new ViewModels.RetailerViewModel { RetailerID = r.Retailer_ID, RetailerName = r.Retailer_Name, RetailerCode = r.Retailer_Code, RetailerLocation = r.Retailer_Location, DepartmentName = d.Department_Name, DepartmentCode = d.Department_Code }).ToList();

            return View(query);
        }

        [HttpPost]
        [ValidateInput(false)]
        public FileResult ExportPdf(string content)
        {
           
                    using (MemoryStream stream = new System.IO.MemoryStream())
                    {
                        StringReader sr = new StringReader(content);
                        Document pdfDoc = new Document(PageSize.A4, 30f, 20f, 30f, 20f);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        pdfDoc.Close();
                        return File(stream.ToArray(), "application/pdf", "Report.pdf");
                    }
                 
        }

        [HttpPost]
        [ValidateInput(false)]
        public FileResult ExportExcel(string content)
        {
            return File(Encoding.ASCII.GetBytes(content), "application/vnd.ms-excel", "Report.xls");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ExportGdrive(string content)
        {
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(content);
                Document pdfDoc = new Document(PageSize.A4, 30f, 20f, 30f, 20f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(Server.MapPath("~/GDrive/Report.pdf"), FileMode.Create)); //PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                
                pdfDoc.Close();

                FileStream file = System.IO.File.Open(Server.MapPath("~/GDrive/Report.pdf"), FileMode.Open); //System.IO.File.Open( ("~/GDrive/Report.pdf");
                
                // Upload file to root folder
                //GoogleDriveAPIHelper.UplaodFileOnDrive(file);

                // Upload file to specific folder
                GoogleDriveAPIHelper.FileUploadInFolder("1bEuGDeH8jKmBsOvwJl0AVKfalF0OHlPR", file);
                ViewBag.Success = "File Uploaded on Google Drive.";
                return View();             
            }
        }

    }
}
