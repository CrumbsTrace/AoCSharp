using AdventOfCode;
using BenchmarkDotNet.Running;

RunBenchmarks(2024);
return;

static void RunBenchmarks(int? year = null, int? day = null)
{
    var benchMarkPattern = day == null ? ".*" : $".*Day{day:D2}.*";
    var config = Helpers.GetConfig(benchMarkPattern);
    var assemblies = AppDomain.CurrentDomain.GetAssemblies();
    var assembly = assemblies.First(a => a.FullName!.StartsWith("AdventOfCode"));
    if (year == null)
    {
        BenchmarkRunner.Run(assembly, config);
    }
    else
    {
        var benchmarkType = assembly.GetTypes().First(t => t.FullName!.Contains($"Year{year}.Benches"));
        BenchmarkRunner.Run(benchmarkType, config);
    }
}
