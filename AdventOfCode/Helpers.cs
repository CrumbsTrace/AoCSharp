using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Filters;

namespace AdventOfCode;

public static partial class Helpers
{
    private static string BasePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Split(["AdventOfCode"], StringSplitOptions.None)[0], "AdventOfCode");
   
    public static string GetInput(int year, int day) => File.ReadAllText(Path.Combine(BasePath, $"Year{year}/inputs/day{day:D2}.txt"));

    public static string[] GetInputLines(int year, int day) => File.ReadAllLines(Path.Combine(BasePath, $"Year{year}/inputs/day{day:D2}.txt"));
    
    public static Dictionary<T, int> CountsOrdered<T>(this List<T> list)
        where T : IEquatable<T>
    {
        var counts = new Dictionary<T, int>();
        var previous = list[0];
        var currentCount = 1;
        foreach (var x in CollectionsMarshal.AsSpan(list)[1..])
        {
            if (x.Equals(previous))
                currentCount++;
            else
            {
                counts.Add(previous, currentCount); 
                previous = x;
                currentCount = 1;
            }
        };
        counts.Add(previous, 1);
        return counts;
    }
    
    public static ManualConfig GetConfig(string namePattern) => DefaultConfig.Instance
        .AddFilter(new NameFilter(name => Regex.IsMatch(name, namePattern)))
        .AddDiagnoser(new MemoryDiagnoser(new MemoryDiagnoserConfig(false)));
    
    [GeneratedRegex(@"\d+")]
    public static partial Regex DigitRegex { get; }
    
}
