using System.Diagnostics;

var input = File.ReadAllText($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");

var endlessTimer = new Stopwatch();

endlessTimer.Start();
var parser = new Parser();

(var cave, var start) = parser.Parse(input);

var sandFactory = new SandFactory();

var caveFiller = new SandSlide();
caveFiller.FillThatCave(cave, sandFactory, start);

endlessTimer.Stop();

Console.WriteLine(caveFiller.Steps);

var flooredTimer = new Stopwatch();

flooredTimer.Start();
var parser2 = new Parser();

(var cave2, var start2) = parser2.ParseWithFloor(input);

var sandFactory2 = new SandFactory();

var caveFiller2 = new SandSlide();

caveFiller2.FillThatCave(cave2, sandFactory2, start2);

flooredTimer.Stop();    
Console.WriteLine(caveFiller2.Steps + 1);

Console.WriteLine();
Console.WriteLine($"infinite cave: {endlessTimer.Elapsed.TotalMilliseconds} ms");
Console.WriteLine($"finite cave: {flooredTimer.Elapsed.TotalMilliseconds} ms");