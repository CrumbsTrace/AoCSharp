namespace AdventOfCode.Year2024;

public static class Day01
{
    public static (int, int) Run(string[] input)
    {
        List<int> list1 = new(input.Length), list2 = new(input.Length);
        foreach(var line in input.AsSpan())
        {
            var enumerator = line.AsSpan().Split("   ");
            list1.Add(GetNextResult(ref enumerator, line));
            list2.Add(GetNextResult(ref enumerator, line));
        }
        list1.Sort(); 
        list2.Sort();
        
        //Take advantage of the fact that the lists are sorted
        var counts = list2.CountsOrdered();
        int p1 = 0, p2 = 0;
        for (var i = 0; i < list1.Count; i++)
        {
            p1 += Math.Abs(list1[i] - list2[i]);
            p2 += counts.GetValueOrDefault(list1[i]) * list1[i];
        }
        return (p1, p2);
    }
    
    private static int GetNextResult(ref MemoryExtensions.SpanSplitEnumerator<char> enumerator, ReadOnlySpan<char> input)
    {
        enumerator.MoveNext();
        return int.Parse(input[enumerator.Current]);
    }
}