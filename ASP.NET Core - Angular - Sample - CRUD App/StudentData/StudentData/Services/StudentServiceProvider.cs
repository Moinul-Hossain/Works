using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentData.Models;
using StudentData.Data;

namespace StudentData.Services
{
    public class StudentServiceProvider : IStudentDataService
    {
        private readonly StudentContext _context;

        public StudentServiceProvider(StudentContext context)
        {
            _context = context;
        }

        public Task<List<Student>> List ()
        {
            var students = _context.Students.ToList();
            return Task.FromResult(students);
        }

        public Task<Student> Details (int? Id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == Id);
            return Task.FromResult(student);
        }

        public Task<Student> Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return Task.FromResult(student);
        }

        public Task<Student> Edit(Student student)
        {
            var stdUpdate = _context.Students.FirstOrDefault
                            (s => s.Id == student.Id);
            stdUpdate.Name = student.Name;
            stdUpdate.Round = student.Round;
            stdUpdate.Batch = student.Batch;
            stdUpdate.Course = student.Course;
            stdUpdate.Address = student.Address;
            stdUpdate.Status = student.Status;
            _context.SaveChanges();

            return Task.FromResult(stdUpdate);
        }

        public Task<List<Student>> Delete (int? Id)
        {
            var student = _context.Students.FirstOrDefault
                          (s => s.Id == Id);                        
            _context.Students.Remove(student);
            _context.SaveChanges();
            return Task.FromResult(_context.Students.ToList());
        }                           
    }
}