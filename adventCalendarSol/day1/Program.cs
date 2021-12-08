// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var list = (await File.ReadAllLinesAsync(@"input.txt")).Select(int.Parse).ToList();

// Part 1 
var response = CompareAndGetTotal(list);

Console.WriteLine($"increased => {response}");
Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>");


var array = list.ToArray();
var l = new List<int>();
for (int i = 3; i <= list.Count; i++)
{
    var o = array[(i - 3)..i];
    l.Add(SumOfThings(o.ToList()));
}

var response2 = CompareAndGetTotal(l);

Console.WriteLine($"increased => {response2}");
Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>");

// Functions
int SumOfThings(List<int> sumOf) =>
    sumOf.Aggregate(0, (total, next) => total + next);

int CompareAndGetTotal(List<int> l) =>
    l.Skip(1)
     .Zip(l, (second, first) => (first, second))
     .Aggregate(0, (total, next) => next.first < next.second ? total + 1 : total);
