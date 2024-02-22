using ExperienceMap.Data;

public static class Seed{

    //new() {"Diploma of Technology", "Technician Diplomas", "Technical Certificates", "Bachelor Degrees", "Undergraduate Certificate", "Advanced Diplomas"};
    //public List<string> programs = new() {"Marine Engineering", "Marine Environmental", "Marine Engineering Systems Design", "Nautical Science", "Naval Architecture", "Ocean Mapping", "Underwater Vehicles"};
    public static void Init(CourseContext db){
        
/*db.SoftSkills.AddRange(
            [
                new() {ID = "skill1"},
                new() {ID = "skill2"},
                new() {ID = "skill3"},
                new() {ID = "skill4"}
            ]
        );*/
/*
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
        ];*/

        Course[] courses = (new List<string> {
            "CMSK 1105 (Technical Communications I)",
            "ELTK 1102 (Electrotechnology)",
            "ENGR 1105 (Engineering Graphics)",
            "MATH 1114 (Pre-Calculus)",
            "MREK 1101 (Marine Engineering Knowledge I)",
            "PHYS 1103 (Physics)",
            "WKPR 1110 (Fitting Shop 1)",
            "CMSK 1205 (Technical Communications II)",
            "ELTK 1202 (Electrotechnology)",
            "ENGR 1102 (Engineering Drawing)",
            "FLDS 2105 (Fluid Mechanics)",
            "MATH 1214 (MENG Mathematics)",
            "MREK 1201 (Marine Engineering Knowledge II)",
            "WKPR 1200 (Fitting Shop II)",
            "MTPR 1300 (Materials & Processes)",
            "SFTY 1102 (Marine Basic First Aid)",
            "SFTY 1114 (BASIC SAFETY - STCW'95 VI/I)",
            "WKPR 1109 (Welding Shop I)",
            "ELTK 2119 (Marine Electrical Systems)",
            "FLDS 3105 (Hydraulics and Pneumatics)",
            "MECH 2111 (Statics and Dynamics)",
            "MREK 2111 (Marine Engineering Knowledge III)",
            "TRMO 2105 (Thermodynamics)",
            "WKPR 1117 (Machine Shop I)",
            "BSMG 3113 (Personal Resource Management)",
            "MECH 2207 (Theory of Machines)",
            "MREK 2209 (Marine Engineering Knowledge IV)",
            "MTPR 2108 (Strength of Materials)",
            "NARC 2228 (Shipbuilding)",
            "TRMO 2204 (Thermodynamics)",
            "WKPR 2113 (Welding Shop II)",
            "WKPR 2117 (Machine Shop II)",
            "ELTK 2303 (Electro-Maintenance)",
            "NARC 2318 (Shipbuilding - Mechanical)",
            "SFTY 1123 (Oil and Chemical Tanker Familiarization)",
            "SFTY 1124 (Confined Space Entry Awareness)",
            "SFTY 1129 (Security Awareness for Seafarers with DSD)",
            "SFTY 1137 (Fall Protection (Offshore))",
            "WKPR 2217 (Machine Shop III)",
            "ELTK 3203 (Rotating AC Machines)",
            "ELTR 3123 (Electronic Devices & Digital Systems)",
            "MREK 3107 (Marine Engineering Knowledge V)",
            "MTPR 3104 (Strength of Materials)",
            "NARC 3110 (Rudders and Propulsion)",
            "TRMO 3107 (Thermodynamics)",
            "CNTL 3205 (Marine Process Measurements and Controls)",
            "ELTK 3204 (DC Machines and Transformers)",
            "MREK 3206 (Marine Engineering Knowledge VI)",
            "MREK 3207 (Industrial Chemistry)",
            "BSMG 3401 (Marine Law and Environmental Stewardship)",
            "CNTL 3401 (Marine Automatic Control Systems)",
            "ELTK 3400 (Shipboard Voltage Distribution Systems)",
            "MREK 3400 (Marine Engineering Knowledge VII)",
            "MREK 340AM (Propulsion Plant Simulator Training)",
            "NARC 3400 (Naval Architecture - Ship Stability)",
            "BSMG 3301 (Leadership and Teamwork)",
            "MREK 340BM (Propulsion Plant Simulator Training)",
            "SFTY 1106 (Marine Advanced First Aid)",
            "SFTY 1117 (Survival Craft - STCW'95 VI/2)",
            "SFTY 1118 (Advanced Firefighting - STCW'95 VI/3 & Officer Certification)",
        }).Select(x => new Course() {ID = x}).ToArray();

        List<Term> terms = [
            new() {Courses = courses[..7].ToList(), TermNo = TermNo.T1},
            new() {Courses = courses[7..14].ToList(), TermNo = TermNo.T2},
            new() {Courses = courses[14..18].ToList(), TermNo = TermNo.TS1},
            new() {Courses = courses[18..24].ToList(), TermNo = TermNo.T3},
            new() {Courses = courses[24..32].ToList(), TermNo = TermNo.T4},
            new() {Courses = courses[32..39].ToList(), TermNo = TermNo.TS2},
            new() {Courses = courses[39..45].ToList(), TermNo = TermNo.T5},
            new() {Courses = courses[45..49].ToList(), TermNo = TermNo.T6},
            new() {Courses = courses[49..55].ToList(), TermNo = TermNo.T7},
            new() {Courses = courses[55..60].ToList(), TermNo = TermNo.TS3},
        ];

        db.Degrees.Add(
            new() {ID = "Diploma of Technology",
            Programs = [ new() {
                ID = "Marine Engineering",
                Terms = terms
                }
            ]}
        );

        db.SaveChanges();

    }
}