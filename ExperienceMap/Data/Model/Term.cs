namespace ExperienceMap.Data;

public enum TermNo {
    T1, T2, TS1, T3, T4, TS2, T5, T6, T7, TS3
}


public class Term
{
    public string ID { get; set; } = "defaultID";
    public TermNo TermNo { get; set;}
    public List<Course> Courses { get; set; } = [];
}