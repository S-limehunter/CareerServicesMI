namespace ExperienceMap.Data;

public class Skill {
    public string ID { get; set; } = "defaultID";
    public virtual List<Course> Courses { get; set; } = [];
}