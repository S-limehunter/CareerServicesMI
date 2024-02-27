using Microsoft.EntityFrameworkCore;

namespace ExperienceMap.Data;

internal class TermIndices {
    public int[] Indices { get; set; } = [];
}

public class ControllerJson(DbContext db)
{
    private static readonly string JsonPath = Path.Combine(Directory.GetCurrentDirectory(), "ExampleData.json");
    private readonly DbContext _db = db;

    
}