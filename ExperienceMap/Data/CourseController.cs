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
    public async Task<ActionResult<Tuple<List<CourseViewModel>,List<SkillViewModel>>>> GetJson(){
        var courses = (await _db.Courses.Include(x => x.Outcomes).ToListAsync()).Select(x => new CourseViewModel(x)).ToList();
        var skills = (await _db.Skills.ToListAsync()).Select(x => new SkillViewModel(x)).ToList();
        return new Tuple<List<CourseViewModel>,List<SkillViewModel>>(courses, skills);
    }

    /*public Tuple<List<Course>, List<Skill>> GetData(){
        return new(_db.Courses.Include(x => x.Outcomes).ToList(), _db.Skills.ToList());
    }*/

    public class CourseViewModel(Course _c){
        public string ID { get; set; } = _c.ID;
        public List<SkillViewModel> Outcomes { get; set; } = _c.Outcomes.Select(x => new SkillViewModel(x)).ToList();
    }

    public class SkillViewModel(Skill _s) {
        public string ID { get; set; } = _s.ID;
    }
}