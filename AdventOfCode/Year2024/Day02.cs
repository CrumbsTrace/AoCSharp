namespace AdventOfCode.Year2024;

public static class Day02
{
    public static (int, int) Run(string[] input)
    {
        int p1 = 0, p2 = 0;
        Parallel.ForEach(input, line =>
        {
            var numbers = line.GetNumberSequence().ToArray();
            CheckLine(numbers, ref p1, ref p2);
        });
        return (p1, p2);
    }

    private static void CheckLine(int[] numbers, ref int p1, ref int p2)
    {
        for (var ignoredIndex = -1; ignoredIndex < numbers.Length; ignoredIndex++)
        {
            if (!TryOption(numbers, true, ignoredIndex) && !TryOption(numbers, false, ignoredIndex))
                continue;
            
            if (ignoredIndex == -1)
                Interlocked.Increment(ref p1);
            Interlocked.Increment(ref p2);
            return;
        }
    }

    private static bool TryOption(int[] numbers, bool increasing, int ignoredIndex)
    {
        int? previous = null;
        for (var j = 0; j < numbers.Length; j++)
        {
            if (ignoredIndex == j) continue;
            if (previous.HasValue)
            {
                var diff = increasing ? numbers[j] - previous.Value : previous.Value - numbers[j];
                if (diff is not (> 0 and < 4))
                    return false;
            }
            previous = numbers[j];
        }
        return true;
    }
}