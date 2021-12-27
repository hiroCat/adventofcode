
var list = await File.ReadAllLinesAsync(@"input.txt");

var calledNumbers = list[0].Split(',').Select(x => int.TryParse(x, out var res)? res: 0);
var grids = new List<Board>();
var currentB = new List<Number>();

foreach (var line in list[2..])
{
    if (string.IsNullOrEmpty(line))
    {
        grids.Add(new Board(currentB));
        currentB = new List<Number>();
    }
    else
    {
        currentB.AddRange(transformString(line));
    }
}

var winnerScore = 0;

foreach (var number in calledNumbers)
{
    foreach (var b in grids)
    {
        markNumberInBoard(b, number);
        if (isBoardWin(b))
        {
            winnerScore = calculatePoints(b);
            break;
        }
    }
    if (winnerScore != 0)
        break;
}

//foreach (var item in grids)
//    printBoard(item);

Console.WriteLine($"result => {winnerScore}");
Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>");

// Functions 

List<Number> transformString(string input) =>
    input.Split(" ")
         .Where(x => !string.IsNullOrEmpty(x))
         .Select(x => new Number(x))
         .ToList();

bool isBoardWin(Board board)
{
    if (board.NumberOfFoundNumb < 5)
        return false;
    for (int i = 0; i+5 < board.BoardNumbers.Count; i+=5)
    {
        if(board.BoardNumbers.ToArray()[i..(i+5)].All(x => x.Marked))
            return true;
    }

    foreach (var i in Enumerable.Range(0, 5))
    {
        if (board.BoardNumbers[i].Marked &&
            board.BoardNumbers[i+5].Marked &&
            board.BoardNumbers[i+10].Marked &&
            board.BoardNumbers[i+15].Marked &&
            board.BoardNumbers[i+20].Marked)
            return true;

    }
    return false;
}

void markNumberInBoard(Board board, int number)
{
    foreach (var item in board.BoardNumbers)
    {
        if (item.Value == number)
        {
            item.Marked = true;
            board.NumberOfFoundNumb++;
            board.lastEvalNumber = number;
            break;
        }
    }
}

int calculatePoints(Board board) => 
    board.BoardNumbers.Where(x => !x.Marked).Select(x => x.Value).Sum() * board.lastEvalNumber;

void printBoard(Board b)
{
    Console.WriteLine("----");
    Console.WriteLine($"{b.lastEvalNumber}-{b.NumberOfFoundNumb}");
    for (int i = 0; i < b.BoardNumbers.Count; i++)
    {
        if (i % 5 == 0)
            Console.WriteLine(Environment.NewLine);
        var t = b.BoardNumbers[i].Marked ? 1 : 0;
        Console.Write($"{b.BoardNumbers[i].Value}({t}) ");
    }
    Console.WriteLine("----");
}

public class Number
{
    public Number(string value)
    {
        Value = int.TryParse(value, out var pValue) ? pValue : 0;
        Marked = false;
    }

    public int Value { get; set; }

    public bool Marked { get; set; }
}

public class Board
{
    public Board(List<Number> boardN)
    {
        BoardNumbers = boardN;
        Points = 0;
        lastEvalNumber = 0;
        NumberOfFoundNumb = 0;
    }

    public int Points { get; set; }

    public int NumberOfFoundNumb { get; set; }

    public int lastEvalNumber { get; set; }

    public List<Number> BoardNumbers { get; set; }
}