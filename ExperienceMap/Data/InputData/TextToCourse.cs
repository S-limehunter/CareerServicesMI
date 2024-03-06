using AntDesign;
using Microsoft.EntityFrameworkCore;

namespace ExperienceMap.Data.Input;

public class TextToCourse
{
    //private static readonly string JsonPath = Path.Combine(Directory.GetCurrentDirectory(), "ExampleData.json");

    public static void ParseCourseText(string path, CourseContext db){
        try {
            using (var file = new StreamReader(path)) {
                //Console.WriteLine(file.ReadToEnd());
                string CourseName = "";
                string CourseTitle = "";
                string OutcomeString = "";
                List<string> Skills = [];

                string? currentLine = "";

                {
                    string? dud = file.ReadLine();
                    CourseName = file.ReadLine() ?? "NAME_ERR";
                    CourseTitle = file.ReadLine() ?? "TITLE_ERR";
                }                
                do {
                    currentLine = file.ReadLine(); 
                    if (!String.IsNullOrWhiteSpace(currentLine) && currentLine.Length > 1) {
                        if (char.IsDigit(currentLine[0]) && currentLine[1] == ')') {
                            OutcomeString += currentLine.Remove(0, 5);
                            string s = OutcomeString.Substring(0, 1).ToLower() + OutcomeString.Substring(1);
                            OutcomeString = s;

                            OutcomeString = "An understanding of " + OutcomeString;
                            Skills.Add(OutcomeString);
                        }
                        if (currentLine[0] == '*') {

                            OutcomeString += currentLine.Remove(0,1);
                            Skills.Add(OutcomeString);
                        }
                        OutcomeString = "";
                    }

                } while (currentLine != null);
                //Console.WriteLine(OutcomeString);
                //Skills = OutcomeString.Split('*'); 
                db.Courses.Add(new() {ID = CourseName, Title = CourseTitle, Outcomes = Skills.Select(x => new Skill() {ID = x}).ToList()});
            } 
        } catch (NotSupportedException) {
            Console.WriteLine("File format not supprted.");
        }
    }

    public static void ParseProgramText(string path, CourseContext db){
        
        try {
            using (var file = new StreamReader(path)){
                string programName = "";
                string degreeName = "";
                int termCount = 0;
                int termCounter = 0;
                Program toAdd = new();

                string? currentLine = "";

                
                {
                    string? dud = file.ReadLine();
                    string nameLine = file.ReadLine() ?? "NAME_ERR - TITLE_ERR";
                    string[] fullTitle = nameLine.Remove(0,5).Split(" - ");
                    degreeName = fullTitle[0];
                    programName = fullTitle[1];
                }
                
                do {
                    currentLine = file.ReadLine();

                    if (String.IsNullOrWhiteSpace(currentLine)){
                        continue;
                    }

                    if (currentLine.Contains("Program Length")) {
                        int first = currentLine.IndexOf('(');
                        int last = currentLine.LastIndexOf(',');

                        int length = last - first;

                        string stuffInBrackets = currentLine.Substring(first, length);
                        string[] bracketArray = stuffInBrackets.Split(", ");
                        foreach (var stuff in bracketArray) {
                            termCount += Convert.ToInt32(stuff[0]);
                        }

                        toAdd = new(termCount);
                    }

                    if (currentLine.Substring(0, 4) == "TERM" || currentLine.Contains("Technical Session")) {
                        List<string> courseIDs = []; //???
                        if (currentLine.Contains("Technical Session")) {
                            for (int i = 0; i < 4; i++) {
                            currentLine = file.ReadLine();
                            }
                        }
                        else {
                            currentLine = file.ReadLine();
                            currentLine = file.ReadLine();
                        }
                        
                        while (!String.IsNullOrWhiteSpace(currentLine)) {
                            courseIDs.Add(currentLine);
                            currentLine = file.ReadLine();
                            // idk how to relate these to the other course info 
                        }

                        toAdd.Terms.Add(new() {TermNo = (TermNo)termCounter});

                        foreach (var course in courseIDs) {
                            toAdd.AddCourseToTerm(db, (TermNo)termCounter, course);
                        }
                    }

                    /*if (currentLine.Contains("Technical Session")) {
                        List<string> courseIDs = [];
                       
                        for (int i = 0; i < 4; i++) {
                            currentLine = file.ReadLine();
                        }
                        while (!String.IsNullOrWhiteSpace(currentLine)) {
                            // same thing 
                            courseIDs.Add(currentLine);
                            currentLine = file.ReadLine();
                        }

                        toAdd.Terms.Add(new() {TermNo = (TermNo)termCounter});

                        foreach (var course in courseIDs) {
                            toAdd.AddCourseToTerm(db, (TermNo)termCounter, course);
                        }
                    }*/
                } while(currentLine != null);

                Degree? d = db.Degrees.Find(degreeName);
                if (d is not null){
                    d.Programs.Add(toAdd);
                } else {
                    d = new() {ID = degreeName};
                    d.Programs.Add(toAdd);
                    db.Degrees.Add(d);
                }
            } 
        }
        catch (NotSupportedException) {
            Console.WriteLine("File format not supported");
        }

    }
    
}