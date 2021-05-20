using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentData.Services;
using StudentData.Models;

namespace StudentData.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentDataService _service;
        public StudentController (IStudentDataService service)
        {
            _service = service;
        }        

        public async Task<IActionResult> Index()
        {
            var students = await _service.List();

            var model = new StudentListViewModel()
            {
                Students = students
            };

            return new JsonResult(model);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var student = await _service.Details(Id);

            var model = new StudentViewModel()
            {
                Student = student
            };

            return new JsonResult(model);
        }

        public async Task<IActionResult> Delete(int? Id)
        {
            var students = await _service.Delete(Id);

            var model = new StudentListViewModel()
            {
                Students = students
            };

            return new JsonResult(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create (Student student)
        {
            var istudent = await _service.Create(student);

            var model = new StudentViewModel()
            {
                Student = istudent
            };

            return new JsonResult(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit (Student student)
        {
            var estudent = await _service.Edit(student);

            var model = new StudentViewModel()
            {
                Student = estudent
            };

            return new JsonResult(model);
        }
    }
}