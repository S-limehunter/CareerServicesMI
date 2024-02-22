namespace ExperienceMap.Data;

public class Course {
    public string ID {get; set;} = "defaultID";
    public List<Skill> Outcomes { get; set; } = [];

    public virtual List<Term> Terms { get; set; } = [];
    public List<TermCourse> TermCourses { get ; set; }
}