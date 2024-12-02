namespace AdventOfCode.Year2023;

public static class Day04
{
    private static readonly char[] Separators = [':', '|'];
    
    public static (int, uint) Run(string[] lines)
    {
        var points = 0;
        Span<uint> counts = stackalloc uint[lines.Length];
        counts.Fill(1);
        
        //Prepare the parsed data in parallel
        //Since none access the same index, we can safely use Parallel.For without locks
        var winsPerLine = new int[lines.Length];
        Parallel.For(0, lines.Length, i =>
        {
            var cards = lines[i].Split(Separators);
            var winning = cards[1].Split(' ').ToHashSet();
            var ours = cards[2].Split(' ');
            winsPerLine[i] = ours.Count(our => our != string.Empty && winning.Contains(our));
        });

        for (var i = 0; i < lines.Length; i++)
        {
            var wins = winsPerLine[i];
            for(var j = 0; j < wins; j++)
                counts[i + j + 1] += counts[i];

            if (wins > 0)
                points += 1 << (wins - 1);
        }

        uint part2 = 0;
        foreach (var count in counts)
            part2 += count;

        return (points, part2);
    }
}