using System.Buffers;
using System.Runtime.CompilerServices;

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
        Parallel.ForEach(lines, (line, _) =>
        {
            Interlocked.Add(ref part1, FindResult(line, false));
            Interlocked.Add(ref part2, FindResult(line, true));
        });
        return (part1, part2);
    }

    private static int FindResult(ReadOnlySpan<char> line, bool p2) =>
        GetFirstDigit(line, p2) * 10 + GetLastDigit(line, p2);

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

    private static int GetFirstDigit(ReadOnlySpan<char> line, bool p2)
    {
        var index = p2 ? line.IndexOfAny(P2Search) : line.IndexOfAny(P1Search); 
        return ParseDigitAtStart(line[index..]);
    }

    private static int ParseDigitAtStart(ReadOnlySpan<char> line)
    {
        foreach (var digit in DigitsP2)
        {
            if (!line.StartsWith(digit)) continue;
            return StringToInt(digit);
        }

        return 0;
    }

    private static int StringToInt(ReadOnlySpan<char> span)
    {
        if (span.Length == 1)
        {
            return span[0] - '0';
        }

        return span switch
        {
            "one" => 1,
            "two" => 2,
            "three" => 3,
            "four" => 4,
            "five" => 5,
            "six" => 6,
            "seven" => 7,
            "eight" => 8,
            "nine" => 9,
            _ => 0
        };
    }
}