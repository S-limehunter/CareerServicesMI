namespace ExperienceMap.Data;

public class Program
{
    public string ID { get; set; } = "defaultID";
    public List<Term> Terms { get; set; } = [];

    public string DegreeID { get; set; }
    public Degree Degree { get; set; } 
    public int TermCount { get; set; }

    public Program(){}
    public Program(int terms) {
        TermCount = terms;
        
        for (int i = 0; i < TermCount; i++) {
            Terms.Add(new() {
                TermNo = (TermNo)i
            }
            );
        }
    }
}