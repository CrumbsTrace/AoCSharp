using BenchmarkDotNet.Attributes;

namespace AdventOfCode.Year2024;

#pragma warning disable CA1822

public class Benches
{
    private readonly string[] _day01Input = Helpers.GetInputLines(2024, 1);

    [Benchmark]
    public void Day01() => Year2024.Day01.Run(_day01Input);
}
#pragma warning restore CA1822
