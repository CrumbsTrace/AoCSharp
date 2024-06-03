namespace AdventOfCode.Year2023;

public static class Day04
{
    private static readonly char[] Separators = [':', '|'];
    
    public static (int, uint) Run(string[] lines)
    {
        var points = 0;
        Span<uint> counts = stackalloc uint[lines.Length];
        counts.Fill(1);

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var cards = line.Split(Separators);
            var winning = cards[1].Split(' ').ToHashSet();
            var ours = cards[2].Split(' ');
            var wins = 0;
            foreach (var our in ours)
            {
                if (our == string.Empty || !winning.Contains(our)) continue;
                wins++;
                counts[i + wins] += counts[i];
            }

            if (wins > 0)
                points += 1 << (wins - 1);
        }

        uint part2 = 0;
        foreach (var count in counts)
            part2 += count;

        return (points, part2);
    }
}