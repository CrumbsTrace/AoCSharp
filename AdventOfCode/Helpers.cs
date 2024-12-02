using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Filters;

namespace AdventOfCode;

public static partial class Helpers
{
    private static string BasePath =>
        //If the path contains "AdventOfCode/AdventOfCode/" the folder the project is in is also named "AdventOfCode" 
        Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory.Split(["AdventOfCode"], StringSplitOptions.None)[0], 
            AppDomain.CurrentDomain.BaseDirectory.Contains("AdventOfCode/AdventOfCode") 
                ? "AdventOfCode/AdventOfCode" 
                : "AdventOfCode");

    public static string GetInput(int year, int day) => File.ReadAllText(Path.Combine(BasePath, $"Year{year}/inputs/day{day:D2}.txt"));

    public static IEnumerable<int> GetNumberSequence(this string line)
    {
        var index = 0;
        while (index < line.Length)
        {
            var newIndex = index;
            while (newIndex < line.Length && char.IsDigit(line[newIndex]))
                newIndex++;
            
            yield return int.Parse(line.AsSpan(index, newIndex - index));
            
            index = newIndex + 1;
            while (index < line.Length && !char.IsDigit(line[index]))
                index++;
        }
    }

    public static string[] GetInputLines(int year, int day) => File.ReadAllLines(Path.Combine(BasePath, $"Year{year}/inputs/day{day:D2}.txt"));
    
    public static ManualConfig GetConfig(string namePattern) => DefaultConfig.Instance
        .AddFilter(new NameFilter(name => Regex.IsMatch(name, namePattern)))
        .AddDiagnoser(new MemoryDiagnoser(new MemoryDiagnoserConfig(false)));
    
    [GeneratedRegex(@"\d+")]
    public static partial Regex DigitRegex { get; }
    
}
