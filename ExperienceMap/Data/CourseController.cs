using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExperienceMap.Data;

[Route("allcourses")]
[ApiController]
public class CourseController : Controller {
    private readonly CourseContext _db;

    public CourseController(CourseContext db){
        _db = db;
    }

    [HttpGet]
    public Tuple<List<Course>, List<Skill>> GetData(){
        return new(_db.Courses.Include(x => x.Outcomes).ToList(), _db.Skills.ToList());
    }
    
    /*public async Task<ActionResult<Tuple<List<Course>,List<Skill>>>> GetData(){
        var courses = await _db.Courses.ToListAsync();
        var skills = await _db.Skills.ToListAsync();
        return new Tuple<List<Course>,List<Skill>>(courses, skills);
    }*/
    
}