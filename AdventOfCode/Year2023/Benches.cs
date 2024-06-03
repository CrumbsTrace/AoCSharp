using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Filters;

namespace AdventOfCode.Year2023;

#pragma warning disable CA1822

public class Benches
{
    private readonly string[] _day01Input = Helpers.GetInputLines(2023, 1);
    private readonly string[] _day02Input = Helpers.GetInputLines(2023, 2);
    private readonly string[] _day03Input = Helpers.GetInputLines(2023, 3);
    private readonly string[] _day04Input = Helpers.GetInputLines(2023, 4);

    [Benchmark]
    public void Day01() => Year2023.Day01.Run(_day01Input);

    [Benchmark]
    public void Day02() => Year2023.Day02.Run(_day02Input);
    
    [Benchmark]
    public void Day03() => Year2023.Day03.Run(_day03Input);
    
    [Benchmark]
    public void Day04() => Year2023.Day04.Run(_day04Input);
}
#pragma warning restore CA1822