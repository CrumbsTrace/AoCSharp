namespace AdventOfCode;

public static class Helpers
{
    private static string BasePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Split(["AdventOfCode/"], StringSplitOptions.None)[0], "AdventOfCode/AdventOfCode");
    
    public static string GetInput(int year, int day) => File.ReadAllText(Path.Combine(BasePath, $"Year{year}/inputs/day{day:D2}.txt"));

    public static string[] GetInputLines(int year, int day) => File.ReadAllLines(Path.Combine(BasePath, $"Year{year}/inputs/day{day:D2}.txt"));
}