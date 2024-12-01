namespace AdventOfCode.Year2024;

public static class Day01
{
    public static (int, int) Run(string[] input)
    {
        Span<int> left = stackalloc int[input.Length];
        Span<int> right = stackalloc int[input.Length];
        for (var i = 0; i < input.Length; i++)
        {
            var line = input[i];
            var enumerator = line.AsSpan().Split("   ");
            left[i] = GetNextResult(ref enumerator, line);
            right[i] = GetNextResult(ref enumerator, line);
        }
        left.Sort();
        right.Sort();

        int p1 = 0, p2 = 0, j = 0;
        for (var i = 0; i < left.Length; i++)
        {
            //Take advantage of the fact that the lists are sorted
            var count = 0;
            while (right[j] <= left[i])
            {
                if (right[j] == left[i])
                    count++;
                j++;
            }
            
            p1 += Math.Abs(left[i] - right[i]);
            p2 += count * left[i];
        }

        return (p1, p2);
    }

    private static int GetNextResult(
        ref MemoryExtensions.SpanSplitEnumerator<char> enumerator, 
        ReadOnlySpan<char> input)
    {
        enumerator.MoveNext();
        return int.Parse(input[enumerator.Current]);
    }
}