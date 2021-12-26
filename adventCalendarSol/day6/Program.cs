
var list = (await File.ReadAllLinesAsync(@"input.txt"))
            .First()
            .Split(",")
            .Select(x => int.TryParse(x, out var res) ? res : 0)
            .ToList();


foreach (var line in Enumerable.Range(1,80))
{
    var newCh = new List<int>();
    for (int i = 0; i < list.Count; i++)
    {
        if (list[i] == 0)
        {
            newCh.Add(8);
            list[i] = 6 ;
        }
        else
        {
            list[i]--;
        }
    }
    list.AddRange(newCh);
}

Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>");
Console.WriteLine($"count => {list.Count}");
Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>");

// Functions 
