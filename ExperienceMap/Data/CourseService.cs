using Microsoft.EntityFrameworkCore;
namespace ExperienceMap.Data;

class CourseService(CourseContext _db)
{
    private readonly CourseContext db = _db;

    public async Task<List<Degree>> GetDegreesAsync() {
        return await db.Degrees
        .Include(x => x.Programs)
        .ThenInclude(x => x.Terms)
        .ThenInclude(x => x.Courses)
        .ThenInclude(x => x.Outcomes)
        .ToListAsync();
    }

    /*public async Task<List<SoftSkill>> getSoftSkillsAsync() {
        return await db.SoftSkills.ToListAsync();
    }*/
}