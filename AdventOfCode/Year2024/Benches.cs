using BenchmarkDotNet.Attributes;

namespace AdventOfCode.Year2024;

public class Benches
{
    private readonly string[] _day01Input = Helpers.GetInputLines(2024, 1);
    private readonly string[] _day02Input = Helpers.GetInputLines(2024, 2);

    [Benchmark]
    public void Day01() => Year2024.Day01.Run(_day01Input);
    
    [Benchmark]
    public void Day02() => Year2024.Day02.Run(_day02Input);
}
