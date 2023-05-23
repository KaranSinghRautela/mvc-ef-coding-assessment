using Microsoft.EntityFrameworkCore;
using TrainingManagementSystem.Models;
using TrainingManagementSystem.Controllers;

namespace TrainingManagementSystem.Context
{
    public class TrainingDbContext:DbContext
    {
        public TrainingDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course>Courses { get; set; }
        public DbSet<Batch>Batches { get; set; }
        public DbSet<TrainingManagementSystem.Controllers.BatchViewModel>? BatchViewModel { get; set; }
    }
}
