using Microsoft.EntityFrameworkCore;
namespace ExperienceMap.Data;

public class CourseContext : DbContext {
    public CourseContext(DbContextOptions o) : base(o){}

    public DbSet<Course> Courses { get; set; }
    public DbSet<SoftSkill> SoftSkills { get; set; }
}