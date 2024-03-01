namespace ExperienceMap.Data;

public class Course {
    public string ID {get; set;} = "defaultID";

    public string Title { get; set; } = "defaultTitle";
    public List<Skill> Outcomes { get; set; } = [];

    public virtual List<Term> Terms { get; set; } = [];
}