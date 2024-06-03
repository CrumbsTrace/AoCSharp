namespace AdventOfCode.Year2023;

public static class Day02
{
    private static readonly char[] Separators = [';', ',', ':', ' '];

    public static (long, long) Run(string[] lines)
    {
        long part1 = 0, part2 = 0;
        Parallel.ForEach(lines, (line, _, i) =>
        {
            var counts = new int[3];
            var parts = line.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
            for (var j = 2; j < parts.Length; j += 2)
            {
                var color = parts[j + 1] switch
                {
                    "red" => 0,
                    "green" => 1,
                    _ => 2
                };
                counts[color] = Math.Max(counts[color], int.Parse(parts[j]));
            }

            var power = counts[0] * counts[1] * counts[2];
            Interlocked.Add(ref part2, power);
            if (counts[0] <= 12 && counts[1] <= 13 && counts[2] <= 14)
                Interlocked.Add(ref part1, i + 1);
        });
        return (part1, part2);
    }
}