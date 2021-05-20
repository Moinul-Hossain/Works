using Microsoft.EntityFrameworkCore;
using StudentData.Models;

namespace StudentData.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : 
                                                    base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }        
    }
}
