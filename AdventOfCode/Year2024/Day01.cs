namespace AdventOfCode.Year2024;
public static class Day01
{
    public static (int, int) Run(string[] input)
    {
        List<int> list1 = [], list2 = [];
        foreach(var line in input)
        {
            var parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            list1.Add(int.Parse(parts[0]));
            list2.Add(int.Parse(parts[1]));
        }
        list1.Sort();
        list2.Sort();
        
        //Calculate the differences for each line and sum them up
        var p1 = list1.Zip(list2).Sum(pair => Math.Abs(pair.First - pair.Second));
        
        //Group the counts of each number in list 2
        var counts = list2.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        var p2 = list1.Sum(x => counts.GetValueOrDefault(x) * x);
        return (p1, p2);
    }
}