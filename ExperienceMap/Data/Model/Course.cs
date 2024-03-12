namespace ExperienceMap.Data;

public class Course() {
    public string ID {get; set;} = "defaultID";

    public string Title { get; set; } = "defaultTitle";

    //public List<Skill> Outcomes { get; set; } = [];
    public List<string> Outcomes { get; set; } = [];

    public virtual List<Term> Terms { get; set; } = [];

    public Course(string _ID, string _title) : this() {
        ID = _ID;
        Title = _title;
    }

    public Course(CourseContext db, string _ID, string _title) : this(_ID, _title) {
        db.Courses.Add(this);
    }
}
