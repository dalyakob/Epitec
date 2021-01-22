using DevTraining.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DevTraining.Infrastructure.Data
{
    public class DevTrainingContext : DbContext
    {
        public DevTrainingContext(DbContextOptions<DevTrainingContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
