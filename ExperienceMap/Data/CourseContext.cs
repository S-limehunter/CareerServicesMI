using Microsoft.EntityFrameworkCore;
namespace ExperienceMap.Data;

public class CourseContext : DbContext {
    public CourseContext(DbContextOptions o) : base(o){}

    public DbSet<Degree> Degrees { get; set; }
}