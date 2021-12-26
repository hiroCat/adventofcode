var list = await File.ReadAllLinesAsync(@"input.txt");

var listC = new List<Coordinates>();
(int maxX, int maxY) = (0, 0);
foreach (var line in list)
{
    var input = line.Split(" -> ");
    var start = input.First();
    var end = input.Last();

    var (startX, startY) = getCoordinates(start);
    var (endX, endY) = getCoordinates(end);

    if ( startX == endX || startY == endY)
        listC.Add(new Coordinates(startX, startY, endX, endY));

    maxX = maxX < Math.Max(startX, endX) ? Math.Max(startX, endX) : maxX;
    maxY = maxY < Math.Max(startY, endY) ? Math.Max(startY, endY) : maxY;
}

int[,] matrix = new int[maxX+1, maxY+1];

foreach (var item in listC)
{
    if (item.StartX == item.EndX)
    {
        for (int i = Math.Min(item.StartY, item.EndY); i <= Math.Max(item.StartY, item.EndY); i++)
            matrix[item.StartX, i] += 1;
    }
    else
    {
        for (int i = Math.Min(item.StartX, item.EndX); i <= Math.Max(item.StartX, item.EndX); i++)
            matrix[i, item.StartY] += 1;
    }
}



//printMatrixInv(matrix);

Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>");
Console.WriteLine($"sizeMatr => {countHighVal(matrix)}");
Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>");

// Functions 

(int x, int y) getCoordinates(string input)
{
    var i = input.Split(',');
    return (parseInt(i.First()), parseInt(i.Last()));
}

int parseInt(string input) => 
    int.TryParse(input, out int result) ? result : 0;

int countHighVal(int[,] matrix)
{
    var counted = 0;
    foreach (var item in matrix)
    {
        if (item > 1)
            counted += 1;
    }
    return counted;
}

void printMatrixInv(int[,] matrix)
{
    int rowLength = matrix.GetLength(1);
    int colLength = matrix.GetLength(0);

    for (int i = 0; i < rowLength; i++)
    {
        for (int j = 0; j < colLength; j++)
        {
            Console.Write(string.Format("{0} ", matrix[j,i]));
        }
        Console.Write(Environment.NewLine + Environment.NewLine);
    }
    Console.ReadLine();
}


public class Coordinates
{
    public Coordinates(int xs, int ys, int xe, int ye)
    {
        StartX = xs;
        StartY = ys;
        EndX = xe;
        EndY = ye;
    }
    public int StartX { get; set; }

    public int StartY { get; set; }

    public int EndX { get; set; }

    public int EndY { get; set; }
}