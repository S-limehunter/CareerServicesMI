using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ExperienceMap.Data;

public enum TermNo {
    T1, T2, TS1, T3, T4, TS2, T5, T6, T7, TS3
}

public class Term
{
    [Key]
    public TermNo TermNo { get; set;}
    public List<Course> Courses { get; set; } = [];
    public List<TermCourse> TermCourses { get; set; }
}

public class TermCourse {
    public Term Term { get; set; }
    public int TermID { get; set; }

    public Course Course { get; set; }
    public int CourseID { get; set; }
}