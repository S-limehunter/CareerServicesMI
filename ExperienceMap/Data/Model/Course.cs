namespace ExperienceMap.Data;

public class Course() {
    public string ID {get; set;} = "defaultID";

    public string Title { get; set; } = "defaultTitle";

    //public List<Skill> Outcomes { get; set; } = [];
    public List<string> Outcomes { get; set; } = [];

    public virtual List<TermCourse> Terms { get; set; } = [];

    public Course(CourseContext db) : this() {
        db.Courses.Add(this);
    }
}

public class TermCourse{
    public string CourseID { get; set; }
    public Course Course { get; set; }

    public int TermID { get; set; }
    public Term Term { get; set; }
}