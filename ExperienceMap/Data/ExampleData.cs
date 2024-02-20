using ExperienceMap.Data;

public static class Seed{
    public static void Init(CourseContext db){
        
        db.SoftSkills.AddRange(
            [
                new() {ID = "skill1"},
                new() {ID = "skill2"},
                new() {ID = "skill3"},
                new() {ID = "skill4"}
            ]
        );
        db.SaveChanges();

        //MREK 1101
        string[] MREK1101 = ["Understand the construction and operation of Diesel Engines for ship propulsion and ship service generation systems",
            "Ability to identify how engines are classified in broad categories",
            "Ability to explain construction, material, merits, application, and forces acting on stationary and moving engine parts",
            "Familiarity with Diesel Engine lubrication systems, filters and strainers, and oil sampling practices",
            "Familiarity with basic safe procedures and processes of Fuel and Fuel systems",
            "Knowledge of Diesel Engine cooling and preheating systems",
            "Ability to identify major components of air distributors and electric, air, and hydraulic starters",
            "Knowledge of charge air and exhaust systems",
            "Knowledge of auxiliary Diesel Engine uses and marine propulsion plant layouts",
        ];

        //MENV 1100
        string[] MENV1100 = ["Carry out basic sampling of oceanographic and biological parameters",
            "Basic oceanographic processes pertaining to scientific inquiry",
            "Skill sets for marine science research",
            "Recognize challenges and limitations of field study",
            "Planned and executed field study",
            "Knowledge of safety requirements for fieldwork",
            "Carried out proper labelling procedures for research samples",
            "Experience analyzing biological samples",
            "Experience with chain-of-command procedures",
            "Practical knowledge of physical oceanography; familiarity with wind circulation, maritime climates, ocean currents, wave structure, and tidal formations",
            "Knowledge of seawater content, composition, and chemical makeup",
            "Familiarity with biogeographical research techniques",
            "Demonstrated correct fish tagging technique",
            "Familiarity with fish anatomy",
            "(Demonstrated procedure | knowledge of equipment) for taking fish blood and tissue samples",
        ];

        //MENV 2300
        string[] MENV2300 = ["Overview of global developments related to industrial hygiene",
            "Appreciation of work sites related to environmental industry",
            "Understanding of the factors that affect workplace safety",
            "Exposure to legislation that governs workplace safety",
            "Understanding the roles of employers and employees in maintaining a safe work environment",
            "awareness of the potential for contamination of deleterious substances",
            "Identifying controls to eliminate or reduce workplace hazards",
            "Knowledge of workplace air quality and ventilation safety standards and practices",
            "Awareness of management and unions responsibility in workplace and workers' safety",
            "Knowledge of provincial and federal regulations for air quality and workplace hazards",
            "Familiarity with techniques for investigating, confirming and documenting complaints",
        ];

        db.Courses.AddRange(
            [
                new() {ID = "MREK 1101: Marine Engineering Knowledge I", Outcomes = MREK1101.Select(x => new Skill() {ID = x}).ToList()},
                new() {ID = "MENV 1100: Sampling I", Outcomes = MENV1100.Select(x => new Skill() {ID = x}).ToList()},
                new() {ID = @"MENV 2300: Environmental Applications of
                            Industial Hygiene", Outcomes = MENV2300.Select(x => new Skill() {ID = x}).ToList()}
            ]
        );
        db.SaveChanges();

    }
}