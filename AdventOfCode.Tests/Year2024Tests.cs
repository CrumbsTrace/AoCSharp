namespace AdventOfCode.Tests;

public class Year2024Tests
{
    [Fact]
    public void Day01()
    {
        var input = Helpers.GetInputLines(2024, 1);
        Assert.Equal((3569916, 26407426), Year2024.Day01.Run(input));
    }
    
    [Fact]
    public void Day02()
    {
        var input = Helpers.GetInputLines(2024, 2);
        Assert.Equal((411, 465), Year2024.Day02.Run(input));
    }
}