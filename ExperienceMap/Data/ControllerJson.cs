using Microsoft.EntityFrameworkCore;

namespace ExperienceMap.Data;

public class ControllerJson(DbContext db)
{
    //private static readonly string JsonPath = Path.Combine(Directory.GetCurrentDirectory(), "ExampleData.json");
    private readonly DbContext _db = db;

    public static void ParseCourseText(string path){
        try {
            using (var file = new StreamReader(path)) {
                Console.WriteLine(file.ReadToEnd());
                string CourseName = "";
                string OutcomeString = "";
                string[] Outcomes = [];
            } 
        } catch (NotSupportedException) {
            Console.WriteLine("File format not supprted.");
        }
    }
}