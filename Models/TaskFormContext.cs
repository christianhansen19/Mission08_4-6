using Microsoft.EntityFrameworkCore;

namespace Mission08_4_6.Models
{
    public class TaskFormContext : DbContext
    {
        // Constructor
        public TaskFormContext(DbContextOptions<TaskFormContext> options) : base (options)
        {
            // Come back
        }

        public DbSet<Quadrant> Quadrants { get; set; } // Quadrants Model
        public DbSet<FormResponse> Responses { get; set; } // Responses Model

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Quadrant>().HasData(

                new Quadrant { QuadrantID = 1, QuadrantName = "Quadrant 1" },
                new Quadrant { QuadrantID = 2, QuadrantName = "Quadrant 2" },
                new Quadrant { QuadrantID = 3, QuadrantName = "Quadrant 3" },
                new Quadrant { QuadrantID = 4, QuadrantName = "Quadrant 4" }

            );

            mb.Entity<FormResponse>().HasData(
                // Seeded Database
                new FormResponse
                {
                    TaskID = 1,
                    TaskName = "Homework",
                    DueDate = "1/1/2023",
                    Category = "School",
                    Completed = false,
                    QuadrantID = 1
                }
            );
        }
    }
}