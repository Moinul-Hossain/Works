using System.Collections.Generic;
using System.Linq;
using FeedbackSystems.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackSystems.Controllers
{
    public class IssuesController : Controller
    {
        private readonly FeedbackContext _context;

        public IssuesController(FeedbackContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var issues = _context.Issues.ToList();

            var model = new ListViewModel()
            {
                Issues = issues
            };

            return new JsonResult(model);
        }

        
        [HttpGet("issues/resolve/{id}")]
        public IActionResult SetResolved (int id)
        {
            var _issue = _context.Issues.FirstOrDefault(i => i.ID == id);
            _issue.Done = true;
            _context.SaveChanges();

            var model = new ViewModel()
            {
                issue = _issue
            };

            return new JsonResult(model);
        }

        [HttpGet("issues/raise/{id}")]
        public IActionResult SetUnresolved (int id)
        {
            var _issue = _context.Issues.FirstOrDefault(i => i.ID == id);
            _issue.Done = false;
            _context.SaveChanges();

            var model = new ViewModel()
            {
                issue = _issue
            };

            return new JsonResult(model);
        }

        [HttpPost]
        public IActionResult Update(Issue _issue)
        {
            var uIssue = _context.Issues.FirstOrDefault(i => i.ID == _issue.ID);
            uIssue.Text = _issue.Text;            
            _context.SaveChanges();

            var model = new ViewModel()
            {
                issue = uIssue
            };

            return new JsonResult(model);
        }

        [HttpPost]
        public IActionResult Create (Issue _issue)
        {
            _context.Issues.Add(_issue);                      
            _context.SaveChanges();

            var model = new ViewModel()
            {
                issue = _issue
            };

            return new JsonResult(model);
        }

        [HttpPost]
        public IActionResult Delete ([FromBody] List<Issue> issues)
        {
            _context.Issues.RemoveRange(issues);
            _context.SaveChanges();

            var model = new ListViewModel()
            {
                Issues = _context.Issues.ToList()
            };

            return new JsonResult(model);
        }

        [HttpPost]
        public IActionResult Archive ([FromBody] List<Issue> issues)
        {
            _context.Issues.RemoveRange(issues);            
            _context.SaveChanges();

            var model = new ListViewModel()
            {
                Issues = _context.Issues.ToList()
            };

            return new JsonResult(model);
        }
    }
}