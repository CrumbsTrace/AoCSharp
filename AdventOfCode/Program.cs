using AdventOfCode;
using BenchmarkDotNet.Running;

RunBenchmarks(2023);
return;

static void RunBenchmarks(int year = 2023, int? day = null)
{
    var benchMarkPattern = day == null ? ".*" : $".*Day{day:D2}.*";
    var config = new BenchConfig(benchMarkPattern);
    var assemblies = AppDomain.CurrentDomain.GetAssemblies();
    var assembly = assemblies.First(a => a.FullName!.StartsWith("AdventOfCode"));
    var benchmarkType = assembly.GetTypes().First(t => t.FullName!.Contains($"Year{year}.Benches"));
    BenchmarkRunner.Run(benchmarkType, config);
}
