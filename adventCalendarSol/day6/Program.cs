
var list = (await File.ReadAllLinesAsync(@"input.txt"))
            .First()
            .Split(",")
            .Select(x => int.TryParse(x, out var res) ? res : 0)
            .ToList();


var lanternFishSep = new long[9] {0, 0 , 0 , 0, 0, 0, 0, 0, 0};

foreach (var item in list)
{
    lanternFishSep[item] += 1;
}

//printArrayLantern(0, lanternFishSep);

foreach (var line in Enumerable.Range(1,256))
{
    var lanternFishSepCp = new long[9];

    Array.Copy(lanternFishSep, 1, lanternFishSepCp, 0, lanternFishSep.Length - 1);
    lanternFishSepCp[8] = lanternFishSep[0];
    lanternFishSepCp[6] = lanternFishSepCp[6] + lanternFishSep[0];

    lanternFishSep = lanternFishSepCp;

    //printArrayLantern(line, lanternFishSep);
}


Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>");
Console.WriteLine($"count => {lanternFishSep.ToList().Sum()}");
Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>");


// Functions 
void printArrayLantern(int iteration, long[] lo)
{
    Console.WriteLine($"lanternFish Day {iteration}");
    lo.ToList().ForEach(l => Console.Write($"{l},"));
    Console.WriteLine(Environment.NewLine);
}