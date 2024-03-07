using Microsoft.EntityFrameworkCore;
namespace ExperienceMap.Data;

public class CourseContext : DbContext {
    public CourseContext(DbContextOptions o) : base(o){}

    public DbSet<Degree> Degrees { get; set; }
    public DbSet<Course> Courses { get; set; }

    protected override void OnModelCreating(ModelBuilder mb){
        mb.Entity<TermCourse>().HasKey(tc => new {tc.TermID, tc.CourseID});
    }
}