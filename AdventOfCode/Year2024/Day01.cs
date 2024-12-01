namespace AdventOfCode.Year2024;

public static class Day01
{
    public static (int, int) Run(string[] input)
    {
        List<int> list1 = new(input.Length), list2 = new(input.Length);
        foreach (var line in input.AsSpan())
        {
            var enumerator = line.AsSpan().Split("   ");
            list1.Add(GetNextResult(ref enumerator, line));
            list2.Add(GetNextResult(ref enumerator, line));
        }
        list1.Sort();
        list2.Sort();

        //Take advantage of the fact that the lists are sorted
        using var countEnumerator = list2.CountsOrdered().GetEnumerator();
        int p1 = 0, p2 = 0;
        for (var i = 0; i < list1.Count; i++)
        {
            var current = list1[i];
            p1 += Math.Abs(current - list2[i]);
            p2 += GetFrequency(countEnumerator, current);
        }

        return (p1, p2);
    }

    private static int GetFrequency(IEnumerator<(int, int)> counts, int current)
    {
        while (counts.Current.Item1 < current)
        {
            if (!counts.MoveNext())
                break;
        }
        return counts.Current.Item1 == current ? counts.Current.Item2 * current : 0;
    }

    private static int GetNextResult(ref MemoryExtensions.SpanSplitEnumerator<char> enumerator,
        ReadOnlySpan<char> input)
    {
        enumerator.MoveNext();
        return int.Parse(input[enumerator.Current]);
    }


    private static IEnumerable<(T, int)> CountsOrdered<T>(this List<T> list)
        where T : IEquatable<T>
    {
        var previous = list[0];
        var currentCount = 1;
        for (var i = 1; i < list.Count; i++)
        {
            var x = list[i];
            if (x.Equals(previous))
                currentCount++;
            else
            {
                yield return (previous, currentCount);
                previous = x;
                currentCount = 1;
            }
        }
    }
}