using ExperienceMap.Data;

public static class Seed{
    public static void Init(CourseContext db){
        db.Skills.AddRange(
            [
                new() {ID = "skill1"},
                new() {ID = "skill2"},
                new() {ID = "skill3"},
                new() {ID = "skill4"}
            ]
        );
        db.SaveChanges();

        db.Courses.AddRange(
            [
                new() {ID = "course1", Outcomes = [.. db.Skills]},
                new() {ID = "course2", Outcomes = [.. db.Skills]}
            ]
        );
        db.SaveChanges();

        
    }
}