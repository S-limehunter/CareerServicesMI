using Microsoft.EntityFrameworkCore;

namespace ExperienceMap.Data;

public class ControllerJson(DbContext db)
{
    //private static readonly string JsonPath = Path.Combine(Directory.GetCurrentDirectory(), "ExampleData.json");
    private readonly DbContext _db = db;

    public static void ParseCourseText(string path){
        try {
            using (var file = new StreamReader(path)) {
                //Console.WriteLine(file.ReadToEnd());
                string CourseName = "";
                string OutcomeString = "";
                string[] Outcomes = [];
                bool flag = false;

                string? currentLine = "";
                do {
                    currentLine = file.ReadLine(); 
                    if (!String.IsNullOrWhiteSpace(currentLine) && currentLine.Length > 1) {
                        if (currentLine.Contains("MAJOR TOPICS")) {
                            string? dud = file.ReadLine();
                            CourseName += file.ReadLine();
                            CourseName += file.ReadLine();
                        }  

                        if (currentLine.Contains("LEARNING OBJECTIVES")) {
                            flag = true;
                        }
                        
                        if (Char.IsDigit(currentLine[0]) && (currentLine[1] == ')' || (currentLine[1] == '.' && flag))){
                            OutcomeString += currentLine + '*';
                        }
                    }

                } while (currentLine != null);
                Console.WriteLine(OutcomeString);
                //Outcomes = OutcomeString.Split('*'); 
            } 
        } catch (NotSupportedException) {
            Console.WriteLine("File format not supprted.");
        }
    }
}