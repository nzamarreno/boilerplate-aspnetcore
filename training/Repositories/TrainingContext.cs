using Microsoft.EntityFrameworkCore;
using training.Entities;

namespace training.Repositories
{
    public class TrainingContext : DbContext
    {
        public TrainingContext(DbContextOptions<TrainingContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
