
namespace AdventOfCode.Tests;

public class Year2023Tests
{
    [Fact]
    public void Day01()
    {
        var input = Helpers.GetInputLines(2023, 1);
        Assert.Equal((54304, 54418), Year2023.Day01.Run(input));
    }

    [Fact]
    public void Day02()
    {
        var input = Helpers.GetInputLines(2023, 2);
        Assert.Equal((2105, 72422), Year2023.Day02.Run(input));
    }

    [Fact]
    public void Day03()
    {
        var input = Helpers.GetInputLines(2023, 3);
        Assert.Equal((544433, 76314915), Year2023.Day03.Run(input));
    }
    
    [Fact]
    public void Day04()
    {
        var input = Helpers.GetInputLines(2023, 4);
        Assert.Equal((32001, (uint)5037841), Year2023.Day04.Run(input));
    }
}
