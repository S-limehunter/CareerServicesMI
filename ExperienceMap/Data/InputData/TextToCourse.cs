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
                            string s = OutcomeString.Substring(0).ToLower() + OutcomeString.Substring(1);
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
}