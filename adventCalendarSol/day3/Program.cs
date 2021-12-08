
var list = await File.ReadAllLinesAsync(@"input.txt");

var countedOnes = new List<int> (new int[list.First().Length]);
foreach(var line in list)
{
    for (int i = 0; i < line.Count(); i++)
    {
        if (line[i] == '1')
            countedOnes[i]++;
    }
}

var totalNum = list.Count();

var gm = GammaRate(countedOnes, totalNum/2);
var ep = EpsilonRate(gm);

Console.WriteLine($"{gm} {ep}");

var gmDecimal = Convert.ToInt32(gm, 2);
var epDecimal = Convert.ToInt32(ep, 2);


Console.WriteLine($"powerCons => {gmDecimal} // {epDecimal} => {gmDecimal * epDecimal}");
Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>");


(int depth, int horiz, int aim) r2 = (0, 0, 0);
Console.WriteLine($"finalpos2 => {r2} => {r2.depth * r2.horiz}");
Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>");

// Functions 

string GammaRate(List<int> list, int size) => 
    string.Concat(list.Select(x => x > size ? '1' : '0'));

string EpsilonRate(string gammaRate) =>
    string.Concat(gammaRate.Select(x => x == '0' ? '1' : '0'));