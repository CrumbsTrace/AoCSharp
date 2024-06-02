using BenchmarkDotNet.Running;

var assemblies = AppDomain.CurrentDomain.GetAssemblies();
var yearAssemblies = assemblies.Where(a => a.FullName!.StartsWith("AdventOfCode"));
var benchesTypes = yearAssemblies.SelectMany(a => a.GetTypes().Where(t => t.Name == "Benches"));
BenchmarkRunner.Run(benchesTypes.ToArray());
