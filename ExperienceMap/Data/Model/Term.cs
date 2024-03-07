namespace ExperienceMap.Data;

public enum TermNo {
    T1, T2, TS1, T3, T4, TS2, T5, T6, T7, TS3
}


public class Term
{
    public int ID { get; set; }
    public TermNo TermNo { get; set;}
    public List<TermCourse> Courses { get; set; } = [];

    private static int termCount = 0;

    public Term() {
        termCount++;
        ID = termCount;
    }

    public string TermLabel {
        get {
            switch (TermNo)
            {
                case TermNo.T1:
                    return "Term 1";
                case TermNo.T2:
                    return "Term 2";
                case TermNo.TS1:
                    return "Tech Session 1";
                case TermNo.T3:
                    return "Term 3";
                case TermNo.T4:
                    return "Term 4";
                case TermNo.TS2:
                    return "Tech Session 2";
                case TermNo.T5:
                    return "Term 5";
                case TermNo.T6:
                    return "Term 6";
                case TermNo.T7:
                    return "Term 7";
                case TermNo.TS3:
                    return "Tech Session 3";
                default:
                    return "big problems!";
            }
        }
    }
}