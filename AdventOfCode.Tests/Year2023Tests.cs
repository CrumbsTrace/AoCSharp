
namespace AdventOfCode.Tests;

public class Year2023Tests
{
    [Fact]
    public void Day01()
    {
        var input = Helpers.GetInputLines(2023, 1);
        Assert.Equal((54304, 54418), Year2023.Day01.Run(input));
    }
}
