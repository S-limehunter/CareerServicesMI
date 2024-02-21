namespace ExperienceMap.Data;

public enum TermNo {
    T1, T2, TS1, T3, T4, TS2, T5, T6, T7, TS3
}


public class Term(TermNo tn)
{
    public TermNo TermNo { get; private set;} = tn;
    public List<Course> Courses { get; set; } = [];
}