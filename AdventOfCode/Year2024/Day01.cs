namespace AdventOfCode.Year2024;

public static class Day01
{
    public static (int, int) Run(string[] input)
    {
        int[] left = new int[input.Length], right = new int[input.Length];
        for (var i = 0; i < input.Length; i++)
        {
            var line = input[i].AsSpan();
            var length1 = line.IndexOf(' ');
            var startIndex2 = length1 + 1;
            while (line[startIndex2] == ' ')
                startIndex2++;
            
            left[i] = int.Parse(line[..length1]);
            right[i] = int.Parse(line[startIndex2..]);
        }
        Array.Sort(left);
        Array.Sort(right);

        int p1 = 0, p2 = 0, j = 0;
        for (var i = 0; i < left.Length; i++)
        {
            //Take advantage of the fact that the lists are sorted
            var count = 0;
            while (j < left.Length && right[j] <= left[i])
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
}