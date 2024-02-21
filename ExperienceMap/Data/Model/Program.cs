namespace ExperienceMap.Data;

public class Program
{
    public string ID { get; set; } = "defaultID";
    public List<Term> Terms { get; set; } = [];
    public virtual Degree Degree { get; set; } = new(); 
}