namespace ExperienceMap.Data;

public class Program
{
    public string ID { get; set; } = "defaultID";
    public List<Term> Terms { get; set; } = [];
    public virtual Degree Degree { get; set; } = new(); 
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