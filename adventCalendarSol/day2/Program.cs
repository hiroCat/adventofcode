
var list = (await File.ReadAllLinesAsync(@"input.txt")).ToList();

(int depth , int horiz) r = (0, 0);
list.ForEach(x => r = MovePosition(x, r));

Console.WriteLine($"finalpos => {r} => {r.depth * r.horiz}");
Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>");


(int depth, int horiz, int aim) r2 = (0, 0, 0);
list.ForEach(x => r2 = MovePositionWithAim(x, r2));
Console.WriteLine($"finalpos2 => {r2} => {r2.depth * r2.horiz}");
Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>");

// Functions 
(int depth, int horiz) MovePosition(string move, (int depth, int horiz) currentP)
{
    var splitedM = move.Split(' ');
    var numberMoves = int.Parse(splitedM.Last());
    return splitedM.First() switch
    {
        "forward" => (currentP.depth, currentP.horiz + numberMoves),
        "down" => (currentP.depth + numberMoves, currentP.horiz),
        "up" => (currentP.depth - numberMoves, currentP.horiz),
        _ => currentP
    };
}

(int depth, int horiz, int aim) MovePositionWithAim(string move, (int depth, int horiz, int aim) currentP)
{
    var splitedM = move.Split(' ');
    var numberMoves = int.Parse(splitedM.Last());
    return splitedM.First() switch
    {
        "forward" => (currentP.depth + (currentP.aim * numberMoves), currentP.horiz + numberMoves, currentP.aim),
        "down" => (currentP.depth, currentP.horiz, currentP.aim + numberMoves),
        "up" => (currentP.depth, currentP.horiz, currentP.aim - numberMoves),
        _ => currentP
    };
}