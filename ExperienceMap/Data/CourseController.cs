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
    public async Task<ActionResult<List<Course>>> GetCourses(){
        return await _db.Courses.ToListAsync();
    }
}