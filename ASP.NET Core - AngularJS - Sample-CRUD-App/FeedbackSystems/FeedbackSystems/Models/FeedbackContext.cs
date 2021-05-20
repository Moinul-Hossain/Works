using Microsoft.EntityFrameworkCore;

namespace FeedbackSystems.Models
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext(DbContextOptions<FeedbackContext> options) :
                                                    base(options)
        { }

        public DbSet<Issue> Issues { get; set; }
    }
}
