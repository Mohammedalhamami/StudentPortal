using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
        public DbSet<Student> Students { get; set; }
    }
}
