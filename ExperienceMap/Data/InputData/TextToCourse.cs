using AntDesign;
using Microsoft.EntityFrameworkCore;

namespace ExperienceMap.Data.Input;

public class TextToCourse
{
    public static void ParseCourseText(string path, CourseContext db) {
        try {
            using var file = new StreamReader(path);
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

            currentLine = GetOutcomes(file, ref OutcomeString, Skills);
            db.Courses.Add(new() { ID = CourseName, Title = CourseTitle, Outcomes = Skills });
            db.SaveChanges();
        } catch (NotSupportedException) {
            Console.WriteLine("File format not supprted.");
        }
    }

    private static string? GetOutcomes(StreamReader file, ref string OutcomeString, List<string> Skills)
    {
        string? currentLine;
        do
        {
            currentLine = file.ReadLine();
            if (!String.IsNullOrWhiteSpace(currentLine) && currentLine.Length > 1)
            {
                if (char.IsDigit(currentLine[0]) && currentLine[1] == ')')
                {

                    if (currentLine.Substring(2).Length <= 0)
                    {
                        continue;
                    }

                    OutcomeString += currentLine.Remove(0, 4);
                    Skills.Add(OutcomeString);
                }

                if (currentLine[0] == '*')
                {

                    OutcomeString += currentLine.Remove(0, 1);
                    Skills.Add(OutcomeString);
                }
                OutcomeString = "";
            }

        } while (currentLine != null);

        return currentLine;
    }

    public static void ParseProgramText(string path, CourseContext db){
        
        try
        {
            using var file = new StreamReader(path);
            Console.WriteLine($"Currently Parsing:\n {path}");

            Program toAdd = new();

            string? currentLine = "";

            GetNames(file, out string programName, out string degreeName);

            toAdd = new() { ID = programName };

            // instantiate degree
            MakeDegree(db, toAdd, degreeName);

            //main loop
            bool flag = false;
            int termCounter = 0;
            int tsCounter = 0;
            do
            {
                currentLine = file.ReadLine();

                if (String.IsNullOrWhiteSpace(currentLine))
                {
                    continue;
                }

                if (!flag)
                    flag = currentLine.Contains("Year 1");

                //scan for terms
                ScanTerms(db, file, toAdd, ref currentLine, flag, ref termCounter, ref tsCounter);

            } while (currentLine != null);
        }
        catch (NotSupportedException) 
        {
            Console.WriteLine("File format not supported");
        }

    }

    private static void MakeDegree(CourseContext db, Program toAdd, string degreeName)
    {
        Degree? d = db.Degrees.Find(degreeName);
        if (d is not null)
        {
            d.Programs.Add(toAdd);
        }
        else
        {
            d = new() { ID = degreeName };
            d.Programs.Add(toAdd);
            db.Degrees.Add(d);
        }
    }

    private static void ScanTerms(CourseContext db, StreamReader file, Program toAdd, ref string? currentLine, bool flag, ref int termCounter, ref int tsCounter)
    {
        if (currentLine.Substring(0, 4).ToUpper() == "TERM" || (currentLine.Contains("Technical Session") && flag))
        {

            // get term/techsesh number
            TermNo termNo = GetTermNo(currentLine, ref termCounter, ref tsCounter);

            toAdd.Terms.Add(new() { TermNo = termNo });

            //go to course block
            bool flagtwo = false;
            BreakBlock(file, ref currentLine, ref flagtwo);

            currentLine = GetCourseBlock(file, currentLine, out List<string> courseIDs);

            AddCourses(db, toAdd, courseIDs, termNo);
        }
    }

    private static TermNo GetTermNo(string? currentLine, ref int termCounter, ref int tsCounter)
    {
        TermNo termNo = TermNo.T1;
        if (currentLine.ToLower().Contains("term"))
        {
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
        else
        {
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

        return termNo;
    }

    private static void BreakBlock(StreamReader file, ref string? currentLine, ref bool flagtwo)
    {
        while (!flagtwo)
        {
            currentLine = file.ReadLine();
            bool breakflag = false;

            if (currentLine.Length < 4)
            {
                continue;
            }

            foreach (var letter in currentLine.Substring(0, 4).ToLower())
            {
                breakflag = !char.IsAsciiLetterLower(letter);
            }

            foreach (var number in currentLine.Substring(6, 2))
            {
                breakflag = !char.IsDigit(number);
            }

            if (!breakflag)
            {
                flagtwo = true;
            }
        }
    }

    private static string? GetCourseBlock(StreamReader file, string? currentLine, out List<string> courseIDs)
    {
        List<string> courses = [];

        while (!String.IsNullOrWhiteSpace(currentLine))
        {
            if (currentLine == "or")
            {
                currentLine = file.ReadLine();
                continue;
            }

            if (currentLine.ToLower().StartsWith("one of:"))
            {
                currentLine = currentLine.Remove(0, 8);
            }

            courses.Add(currentLine[..(currentLine.IndexOf('(') - 1)]);
            currentLine = file.ReadLine();
        }
        
        courseIDs = courses;
        return currentLine;
    }

    private static void AddCourses(CourseContext db, Program toAdd, List<string> courseIDs, TermNo termNo)
    {
        foreach (var course in courseIDs)
        {
            toAdd.AddCourseToTerm(db, termNo, course);
        }
    }

    private static void GetNames(StreamReader file, out string programName, out string degreeName)
    {
        _ = file.ReadLine();

        string nameLine = file.ReadLine() ?? throw new NullReferenceException("Unexpected Formatting in Program Doc.");

        string[] fullTitle = nameLine.Remove(0, 5).Split(" - ");
        degreeName = fullTitle[0];
        programName = fullTitle[1];
    }
}