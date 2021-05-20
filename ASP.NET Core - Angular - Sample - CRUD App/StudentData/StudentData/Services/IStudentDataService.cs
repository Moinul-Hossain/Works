using System.Collections.Generic;
using System.Threading.Tasks;
using StudentData.Models;

namespace StudentData.Services
{
    public interface IStudentDataService
    {
        // Student
        Task<List<Student>> List ();
        Task<Student> Details (int? Id);
        Task<Student> Create(Student student);
        Task<Student> Edit(Student student);
        Task<List<Student>> Delete(int? Id);                     
    }
}