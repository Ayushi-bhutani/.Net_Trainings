using System.Text.Json;
namespace student
{
    public record Student(string Name, int Score);
public class Records
{
    public static string BuildResult(string[] items, int minScore)
    {
        var students = new List<Student>(items.Length);
        foreach(var item in items)
        {
            var parts = item.Split(':');
            string name = parts[0];
            int score = int.Parse(parts[1]);

            students.Add(new Student(name, score));
        }

        var result = students 
            .Where(s=>s.Score >= minScore)
            .OrderByDescending(s=>s.Score)
            .ThenBy(s=> s.Name)
            .ToList();

        return JsonSerializer.Serialize(result); 
    }
}
}
