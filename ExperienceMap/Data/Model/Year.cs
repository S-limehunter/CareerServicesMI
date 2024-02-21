namespace ExperienceMap.Data;

public enum YearNo {
    Y1, Y2, Y3, Y4
}

public class Year
{
    public YearNo YearNo { get; private set; }

    public List<Term> Terms { get; set; } = [];
}