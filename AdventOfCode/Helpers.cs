using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Filters;
using BenchmarkDotNet.Loggers;

namespace AdventOfCode;

public static class Helpers
{
    private static string BasePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Split(["AdventOfCode/"], StringSplitOptions.None)[0], "AdventOfCode/AdventOfCode");
    
    public static string GetInput(int year, int day) => File.ReadAllText(Path.Combine(BasePath, $"Year{year}/inputs/day{day:D2}.txt"));

    public static string[] GetInputLines(int year, int day) => File.ReadAllLines(Path.Combine(BasePath, $"Year{year}/inputs/day{day:D2}.txt"));
}

[DryJob]
[Config(typeof(BenchConfig))]
public class BenchConfig : ManualConfig
{
    public BenchConfig(string pattern)
    {
        AddFilter(new NameFilter(name => Regex.IsMatch(name, pattern)));
        
        AddDiagnoser(MemoryDiagnoser.Default);
        AddLogger(ConsoleLogger.Default);
        AddColumnProvider(DefaultColumnProviders.Instance);
        AddExporter(DefaultExporters.Markdown);
    }
}
