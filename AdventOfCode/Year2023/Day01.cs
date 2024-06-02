using System.Runtime.CompilerServices;

namespace AdventOfCode.Year2023;

public static class Day01
{
    private static readonly (string, char)[] Digits =
    [
        ("one", '1'),
        ("two", '2'),
        ("three", '3'),
        ("four", '4'),
        ("five", '5'),
        ("six", '6'),
        ("seven", '7'),
        ("eight", '8'),
        ("nine", '9')
    ];

    public static (int, int) Run(string[] lines)
    {
        int part1 = 0, part2 = 0;
        Parallel.ForEach(lines, (line, _) =>
        {
            Interlocked.Add(ref part1, GetLineResult(line, false));
            Interlocked.Add(ref part2, GetLineResult(line, true));
        });
        return (part1, part2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int GetLineResult(ReadOnlySpan<char> line, bool p2) =>
        GetDigit(line, false, p2) * 10 + GetDigit(line, true, p2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int GetDigit(ReadOnlySpan<char> line, bool last, bool p2)
    {
        while (true)
        {
            foreach (var (text, digit) in Digits)
            {
                if (last)
                {
                    if (line[^1] == digit || (p2 && line.EndsWith(text)))
                        return digit - '0';
                }
                else
                {
                    if (line[0] == digit || (p2 && line.StartsWith(text)))
                        return digit - '0';
                }
            }

            line = last ? line[..^1] : line[1..];
        }
    }
}