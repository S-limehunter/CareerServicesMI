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
    }
}