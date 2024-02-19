using Microsoft.EntityFrameworkCore;
namespace ExperienceMap.Data;

class CourseService(CourseContext _db)
{
    private readonly CourseContext db = _db;

    public async Task<List<Course>> GetCoursesAsync() {
        return await db.Courses.Include(x => x.Outcomes).ToListAsync();
    }

    public async Task<List<Skill>> getSkillsAsync() {
        return await db.Skills.ToListAsync();
    }
}