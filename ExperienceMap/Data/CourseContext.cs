using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
namespace ExperienceMap.Data;

public class CourseContext : DbContext {
    public CourseContext(DbContextOptions o) : base(o){}

    public DbSet<Degree> Degrees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Program>().OwnsMany(p => p.Terms, t => {
            t.WithOwner();
        });
        modelBuilder.Entity<Term>()
            .HasMany(t => t.Courses)
            .WithMany(c => c.Terms)
            .UsingEntity<TermCourse>(
                j => j.HasOne(t => t.Course).WithMany(c => c.TermCourses),
                j => j.HasOne(t => t.Term).WithMany(c => c.TermCourses)
            );
    }
}