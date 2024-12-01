using System.Buffers;

namespace AdventOfCode.Year2023;

public static class Day01
{
    private static readonly SearchValues<char> P1Search = SearchValues.Create("123456789");

    private static readonly string[] DigitsP2 =
    [
        "one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
        "1", "2", "3", "4", "5", "6", "7", "8", "9"
    ];

    private static readonly SearchValues<string> P2Search =
        SearchValues.Create(DigitsP2, StringComparison.OrdinalIgnoreCase);

    public static (int, int) Run(string[] lines)
    {
        int part1 = 0, part2 = 0;
        Parallel.ForEach(lines, line =>
        {
            Interlocked.Add(ref part1, GetFirstDigit(line, false) * 10 + GetLastDigit(line, false));
            Interlocked.Add(ref part2, GetFirstDigit(line, true) * 10 + GetLastDigit(line, true));
        });
        return (part1, part2);
    }

    private static int GetFirstDigit(ReadOnlySpan<char> line, bool p2)
    {
        var index = p2 ? line.IndexOfAny(P2Search) : line.IndexOfAny(P1Search);
        return ParseDigitAtStart(line[index..]);
    }

    private static int GetLastDigit(ReadOnlySpan<char> line, bool p2)
    {
        var index = line.LastIndexOfAny(P1Search);
        if (!p2)
            return line[index] - '0';

        //Unfortunately there is no LastIndexOfAny for SearchValues<string>
        //So we have to just jump to the next digit till we reach the end
        while (index < line.Length - 2)
        {
            var index2 = line[(index + 1)..].IndexOfAny(P2Search);
            if (index2 == -1)
                break;

            index += index2 + 1;
        }

        return ParseDigitAtStart(line[index..]);
    }

    private static int ParseDigitAtStart(ReadOnlySpan<char> line)
    {
        return line[0] switch
        {
            'o' => 1,
            't' => line[1] == 'w' ? 2 : 3,
            'f' => line[1] == 'o' ? 4 : 5,
            's' => line[1] == 'i' ? 6 : 7,
            'e' => 8,
            'n' => 9,
            _ => line[0] - '0'
        };
    }
}
