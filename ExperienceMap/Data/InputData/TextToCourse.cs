using AntDesign;
using Microsoft.EntityFrameworkCore;

namespace ExperienceMap.Data.Input;

public class TextToCourse
{
    //private static readonly string JsonPath = Path.Combine(Directory.GetCurrentDirectory(), "ExampleData.json");

    public static void ParseCourseText(string path, CourseContext db){
        try {
            using (var file = new StreamReader(path)) {
                Console.WriteLine("Currently Parsing: ");
                Console.WriteLine(path);

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
                db.Courses.Add(new() {ID = CourseName, Title = CourseTitle, Outcomes = Skills});
            } 
        } catch (NotSupportedException) {
            Console.WriteLine("File format not supprted.");
        }
    }

    public static void ParseProgramText(string path, CourseContext db){
        
        try {
            using (var file = new StreamReader(path)){
                Console.WriteLine("Currently Parsing: ");
                Console.WriteLine(path);

                string programName = "";
                string degreeName = "";
                int termCounter = 0;
                int tsCounter = 0;
                bool flag = false;
                Program toAdd = new();

                string? currentLine = "";

                
                {
                    string? dud = file.ReadLine();
                    string nameLine = file.ReadLine() ?? "NAME_ERR - TITLE_ERR";
                    string[] fullTitle = nameLine.Remove(0,5).Split(" - ");
                    degreeName = fullTitle[0];
                    programName = fullTitle[1];
                }
                
                toAdd = new() {ID = programName};
                
                do {
                    currentLine = file.ReadLine();

                    if (String.IsNullOrWhiteSpace(currentLine)){
                        continue;
                    }

                    if (!flag)
                        flag = currentLine.Contains("Year 1");

                    if (currentLine.Substring(0, 4).ToUpper() == "TERM" || (currentLine.Contains("Technical Session") && flag)) {
                        List<string> courseIDs = [];

                        TermNo termNo = TermNo.T1;

                        if (currentLine.ToLower().Contains("term")){
                            switch (termCounter)
                            {
                                case 0:
                                    termNo = TermNo.T1;
                                    break;
                                case 1:
                                    termNo = TermNo.T2;
                                    break;
                                case 2:
                                    termNo = TermNo.T3;
                                    break;
                                case 3:
                                    termNo = TermNo.T4;
                                    break;
                                case 4:
                                    termNo = TermNo.T5;
                                    break;
                                case 5:
                                    termNo = TermNo.T6;
                                    break;
                                case 6:
                                    termNo = TermNo.T7;
                                    break;
                            }

                            termCounter++;
                        } 
                        else {
                            switch (tsCounter)
                            {
                                case 0:
                                    termNo = TermNo.TS1;
                                    break;
                                case 1:
                                    termNo = TermNo.TS2;
                                    break;
                                case 2:
                                    termNo = TermNo.TS3;
                                    break;
                            }

                            tsCounter++;
                        }

                        toAdd.Terms.Add(new() {TermNo = termNo});

                        currentLine = file.ReadLine();
                        currentLine = file.ReadLine();
                        if (currentLine.Contains(" – ")){ //THIS UNICODE CHARACTER is EVIL!!!
                            currentLine = file.ReadLine();
                            currentLine = file.ReadLine();
                        }

                        while (!String.IsNullOrWhiteSpace(currentLine)) {
                            courseIDs.Add(currentLine.Substring(0, currentLine.IndexOf('(')-1)); 
                            currentLine = file.ReadLine();
                            // idk how to relate these to the other coursea info 
                        }
                        
                        foreach (var course in courseIDs) {
                            toAdd.AddCourseToTerm(db, termNo, course);
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