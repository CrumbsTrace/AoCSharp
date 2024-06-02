using AdventOfCode;
using BenchmarkDotNet.Running;

RunBenchmarks();
return;

static void RunBenchmarks(string benchMarkPattern = ".*", string? year = null)
{
    var config = new BenchConfig(benchMarkPattern);
    var assemblies = AppDomain.CurrentDomain.GetAssemblies();
    var yearAssemblies = assemblies.Where(a => a.FullName!.StartsWith("AdventOfCode"));
    var benchesTypes = yearAssemblies.SelectMany(a => a.GetTypes().Where(t => t.Name == "Benches" && t.Namespace!.Contains(year ?? "")));
    BenchmarkRunner.Run(benchesTypes.ToArray(), config);
}
