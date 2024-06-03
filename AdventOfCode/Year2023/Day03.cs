namespace AdventOfCode.Year2023;

public static class Day03
{
    public static (int, int) Run(ReadOnlySpan<string> lines)
    {
        var width = lines[0].Length;
        var height = lines.Length;
        var gearParts = new Dictionary<int, (int product, int count)>();
        var part1 = 0;
        for (var y = 0; y < height; y++)
        {
            var line = lines[y];
            var x = 0;
            while (x < width)
            {
                var partNumber = 0;
                var xEnd = x;
                if (char.IsDigit(lines[y][x]))
                    (partNumber, xEnd) = GetPartNumber(x, line);

                if (partNumber > 0)
                {
                    var adjacentSymbols = GetAdjacentSymbols(x, xEnd - 1, y, lines);
                    if (adjacentSymbols.Count > 0)
                    {
                        part1 += partNumber;
                        foreach (var (index, symbol) in adjacentSymbols)
                        {
                            if (symbol != '*') 
                                continue;
                            var (product, count) = gearParts.GetValueOrDefault(index, (0, 0));
                            gearParts[index] = count switch
                            {
                                0 => (partNumber, 1),
                                1 => (product * partNumber, 2),
                                _ => (product, count + 1)
                            };
                        }
                    }
                }
                
                x = xEnd + 1;
            }
        }
        
        var part2 = gearParts.Values.Where(p => p.count == 2).Select(p => p.product).Sum();
        return (part1, part2);
    }

    private static List<(int, char)> GetAdjacentSymbols(int x, int xEnd, int y, ReadOnlySpan<string> lines)
    {
        var adjacentSymbols = new List<(int, char)>();
        var width = lines[0].Length;
        var height = lines.Length;
        for (var yAdj = y - 1; yAdj <= y + 1; yAdj++)
        {
            if (yAdj < 0 || yAdj >= height) continue;
            
            for (var xAdj = x - 1; xAdj <= xEnd + 1; xAdj++)
            {
                if (xAdj < 0 || xAdj >= width) continue;

                var c = lines[yAdj][xAdj];
                if (c != '.' && !char.IsDigit(c))
                    adjacentSymbols.Add((yAdj * lines[0].Length + xAdj, c));
            }
        }

        return adjacentSymbols;
    }

    private static (int partNumber, int xEnd) GetPartNumber(int x, string line)
    {
        var partNumber = 0;
        while (x < line.Length && char.IsDigit(line[x]))
        {
            partNumber = partNumber * 10 + (line[x] - '0');
            x++;
        }
        return (partNumber, x);
    }
}