using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Filters;

namespace AdventOfCode.Year2023;

#pragma warning disable CA1822

public class Benches
{
    private readonly string[] _day01Input = Helpers.GetInputLines(2023, 1);
    
    [Benchmark]
    public void Day1() => Day01.Run(_day01Input);
}
#pragma warning restore CA1822